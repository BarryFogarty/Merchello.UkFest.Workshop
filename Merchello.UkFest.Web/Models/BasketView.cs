namespace Merchello.UkFest.Web.Models
{
    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The render view for the basket page.
    /// </summary>
    public class BasketView
    {
        /// <summary>
        /// Gets or sets the <see cref="UpdateBasket"/> model.
        /// </summary>
        [DittoValueResolver(typeof(UpdateBasketValueResolver))]
        public UpdateBasket UpdateBasket { get; set; }

        /// <summary>
        /// Gets or sets the order summary.
        /// </summary>
        [DittoValueResolver(typeof(OrderSummaryValueResolver))]
        public OrderSummary OrderSummary { get; set; }
    }
}