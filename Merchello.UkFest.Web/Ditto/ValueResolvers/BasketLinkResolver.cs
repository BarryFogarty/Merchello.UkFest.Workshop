namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Models;
    using Merchello.UkFest.Web.Resolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// A resolver for the basket Url.
    /// </summary>
    public class BasketLinkResolver : DittoValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return null;
            var basket = ContentResolver.Instance.GetBasketContent();
            return new Link
                {
                    Url = basket.Url,
                    Title = basket.Name
                };
        }
    }
}