namespace Merchello.UkFest.Web.Models.Checkout
{
    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The checkout model.
    /// </summary>
    public class CheckoutModel
    {
        /// <summary>
        /// Gets or sets the basket url.
        /// </summary>
        [DittoValueResolver(typeof(BasketUrlValueResolver))]
        public string BasketUrl { get; set; }

        /// <summary>
        /// Gets or sets the order summary.
        /// </summary>
        [DittoValueResolver(typeof(OrderSummaryValueResolver))]
        public OrderSummary OrderSummary { get; set; } 
    }
}