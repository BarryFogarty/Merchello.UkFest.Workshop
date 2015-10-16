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
            var shippingRate = 0M;
            var totalTitle = "Sub Total";
            var total = Context.Basket.TotalBasketPrice;
            var preparation = Context.SalePreparation;
            if (!preparation.IsReadyToInvoice())
            {
                var shipment = Context.Basket.PackageBasket(new Address() { CountryCode = "GB" }).FirstOrDefault();
                if (shipment != null)
                {
                    var quote = shipment.ShipmentRateQuotes().FirstOrDefault();
                    if (quote != null) shippingRate = quote.Rate;
                    total += shippingRate;
                }
            }
            else
            {
                totalTitle = "Total";
                total = preparation.PrepareInvoice().Total;
            }

            return new OrderSummary
                       {
                           FormattedSubTotal = StoreHelper.FormatCurrency(Context.Basket.TotalBasketPrice),
                           FormattedShippingTotal = StoreHelper.FormatCurrency(shippingRate),
                           FormattedTotal = StoreHelper.FormatCurrency(total),
                           TotalTitle = totalTitle
                       };
        }
    }
}