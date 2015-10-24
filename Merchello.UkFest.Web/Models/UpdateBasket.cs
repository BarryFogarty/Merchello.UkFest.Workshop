namespace Merchello.UkFest.Web.Models
{
    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// A model used for updating a basket.
    /// </summary>
    public class UpdateBasket
    {
        /// <summary>
        /// Gets or sets the continue shopping url.
        /// </summary>
        [DittoValueResolver(typeof(ContinueShoppingUrlValueResolver))]
        public string ContinueShoppingUrl { get; set; }

        /// <summary>
        /// Gets or sets the formatted basket total.
        /// </summary>
        [DittoValueResolver(typeof(CollectionTotalValueResolver))]
        public string FormattedBasketTotal { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        [DittoValueResolver(typeof(BasketItemValueResolver))]
        public virtual BasketItem[] Items { get; set; }
    }
}