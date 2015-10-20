namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Linq;

    using Merchello.Core.Models;
    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.UkFest.Web.Models;
    using Merchello.Web;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// Resolves the order summary.
    /// </summary>
    public class OrderSummaryValueResolver : DittoValueResolver<CustomerContextValueResolverContext>
    {
        /// <summary>
        /// Creates an order summary.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return null;

            if (Context.SalePreparation.IsReadyToInvoice())
            {
                var invoice = Context.SalePreparation.PrepareInvoice();
                return new OrderSummary
                           {
                               FormattedSubTotal = StoreHelper.FormatCurrency(invoice.TotalItemPrice()),
                               FormattedShippingTotal = StoreHelper.FormatCurrency(invoice.TotalShipping()),
                               FormattedTotal = StoreHelper.FormatCurrency(invoice.Total),
                               Items = invoice.Items,
                               TotalTitle = "Total"
                           };
            }

            var shippingRate = 0M;
            const string TotalTitle = "Sub Total";
            var total = Context.Basket.TotalBasketPrice;
            var shipment = Context.Basket.PackageBasket(new Address() { CountryCode = "GB" }).FirstOrDefault();
            if (shipment != null)
            {
                var quote = shipment.ShipmentRateQuotes().FirstOrDefault();
                if (quote != null) shippingRate = quote.Rate;
                total += shippingRate;
            }
          
            return new OrderSummary
                       {
                           FormattedSubTotal = StoreHelper.FormatCurrency(Context.Basket.TotalBasketPrice),
                           FormattedShippingTotal = StoreHelper.FormatCurrency(shippingRate),
                           FormattedTotal = StoreHelper.FormatCurrency(total),
                           Items = Context.Basket.Items,
                           TotalTitle = TotalTitle
                       };
        }
    }
}