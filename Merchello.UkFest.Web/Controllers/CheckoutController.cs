namespace Merchello.UkFest.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Merchello.Core;
    using Merchello.Core.Models;
    using Merchello.Core.Sales;
    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.UkFest.Web.Models.Checkout;
    using Merchello.UkFest.Web.Resolvers;
    using Merchello.Web;
    using Merchello.Web.Pluggable;
    using Merchello.Web.Workflow;

    using Umbraco.Core.Logging;
    using Umbraco.Web.Models;

    /// <summary>
    /// The checkout controller.
    /// </summary>
    public class CheckoutController : DitFloController
    {
        /// <summary>
        /// The _customer context.
        /// </summary>
        private ICustomerContext _customerContext;

        /// <summary>
        /// The basket.
        /// </summary>
        private IBasket _basket;

        /// <summary>
        /// The <see cref="SalePreparationBase"/>.
        /// </summary>
        private Lazy<IBasketSalePreparation> _preparation; 

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutController"/> class.
        /// </summary>
        public CheckoutController()
        {
            this.Initialize();
        }

        /// <summary>
        /// Renders the checkout page.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Checkout(RenderModel model)
        {
            if (_customerContext.CurrentCustomer.Basket().IsEmpty)
            {
                return this.RedirectToUmbracoPage(ContentResolver.Instance.GetRootContent());
            }

            return this.CurrentView(model);
        }

        #region ChildActions

        /// <summary>
        /// Renders the Address Form.
        /// </summary>
        /// <param name="addressType">
        /// The address type.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public ActionResult AddressForm(AddressType addressType)
        {
            var preparation = _preparation.Value;
            
            var model = preparation.GetBillToAddress() != null ? preparation.GetBillToAddress().AsAddressModel() :
                    new AddressModel();

            model.Step = 1;
            model.PreviousUrl = ContentResolver.Instance.GetBasketContent().Url;

            return this.PartialView(model);
        }

        /// <summary>
        /// Renders the delivery method form.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public ActionResult DeliveryMethod()
        {
            var preparation = _preparation.Value;

            var address = preparation.GetBillToAddress() ?? new AddressModel().AsAddress(AddressType.Shipping);

            var shipment = _basket.PackageBasket(address).FirstOrDefault();

            if (shipment == null)
            {
                LogHelper.Error<CheckoutController>("Shipment was null", new NullReferenceException("Package basket returned a null shipment"));
            }

            var quotes = shipment.ShipmentRateQuotes().ToArray();
            if (!quotes.Any())
            {
                LogHelper.Error<CheckoutController>("No shipping rate quotes where found", new NullReferenceException("No shipping rate quotes"));
            }

            var deliveryQuotes = quotes.Select(x => x.AsDeliveryQuote()).ToArray();
            var shipMethodKey = Guid.Empty;
            if (preparation.IsReadyToInvoice())
            {
                var shipmentLineItem = preparation.PrepareInvoice().ShippingLineItems().FirstOrDefault();
                shipMethodKey = shipmentLineItem != null ? 
                    shipmentLineItem.ExtendedData.GetShipment<InvoiceLineItem>().ShipMethodKey.GetValueOrDefault() : 
                    Guid.Empty;
            }

            shipMethodKey = shipMethodKey.Equals(Guid.Empty) ? deliveryQuotes.First().Key : shipMethodKey;

            return this.PartialView(new DeliveryMethod { ShipMethodKey = shipMethodKey, Quotes = deliveryQuotes });
        }

        /// <summary>
        /// Renders the payment method form.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public ActionResult PaymentMethod()
        {
            var preparation = _preparation.Value;

            var paymentMethods = preparation.GetPaymentGatewayMethods().Select(x => x.PaymentMethod).ToArray();

            var model = new PaymentMethods
                            {
                                Methods = paymentMethods,
                                PreviousUrl = ContentResolver.Instance.GetBasketContent().Url,
                                SelectedPaymentMethod = paymentMethods.First().Key
                            };

            return this.PartialView(model);
        }

        #endregion

        /// <summary>
        /// Saves an address.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAddress(AddressModel model)
        {
            if (!ModelState.IsValid) return this.CurrentUmbracoPage();

            var prepartion = _preparation.Value;

            prepartion.SaveBillToAddress(model.AsAddress(AddressType.Billing));
            prepartion.SaveShipToAddress(model.AsAddress(AddressType.Shipping));

            this.UpdateStage(1);

            return this.CurrentUmbracoPage();
        }

        /// <summary>
        /// Saves the delivery method.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult SaveDeliverMethod(DeliveryMethod model)
        {
            var preparation = _preparation.Value;

            var address = preparation.GetShipToAddress();
            var shipment = _basket.PackageBasket(address).FirstOrDefault();
            preparation.ClearShipmentRateQuotes();

            var quote = shipment.ShipmentRateQuoteByShipMethod(model.ShipMethodKey, false);

            preparation.SaveShipmentRateQuote(quote);

            this.UpdateStage(2);

            return this.CurrentUmbracoPage();
        }

        /// <summary>
        /// Saves the payment method selection.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult SavePaymentMethod(PaymentMethods model)
        {
            var preparation = _preparation.Value;

            var method =
                preparation.GetPaymentGatewayMethods()
                    .FirstOrDefault(x => x.PaymentMethod.Key == model.SelectedPaymentMethod);

            if (method != null)
            preparation.SavePaymentMethod(method.PaymentMethod);

            this.UpdateStage(3);

            return this.CurrentUmbracoPage();
        }

        /// <summary>
        /// Confirms the order.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        /// <remarks>
        /// This method is overly simple since we only have the cash provider installed.
        /// Normally, we'd post values for processing a payment, but in this case we just need to authorize the 
        /// transaction.
        /// </remarks>
        [HttpGet]
        public ActionResult ConfirmOrder()
        {
            var preparation = _preparation.Value;

            var result = preparation.AuthorizePayment(preparation.GetPaymentMethod().Key);

            var context = new ReceiptValueResolverContext();
            context.SetValue(result.Invoice.Key);

            return RedirectToUmbracoPage(ContentResolver.Instance.GetReceiptContent());
        }

        /// <summary>
        /// Starts the checkout.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult StartCheckout()
        {
            var context = new CheckoutStageResolverContext();
            context.SetStage(0);
            return this.RedirectToUmbracoPage(ContentResolver.Instance.GetCheckoutContent());
        }

        /// <summary>
        /// Updates the stage.
        /// </summary>
        /// <param name="stage">
        /// The stage.
        /// </param>
        private void UpdateStage(int stage)
        {
            var context = new CheckoutStageResolverContext();
            context.SetStage(stage);
        }

        /// <summary>
        /// Initializes the controller.
        /// </summary>
        private void Initialize()
        {
            _customerContext = PluggableObjectHelper.GetInstance<CustomerContextBase>("CustomerContext", UmbracoContext);
            _basket = _customerContext.CurrentCustomer.Basket();
            _preparation = new Lazy<IBasketSalePreparation>(() => _basket.SalePreparation());
        }
    }
}