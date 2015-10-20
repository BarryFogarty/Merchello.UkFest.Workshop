namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Resolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// Resolves the basket URL.
    /// </summary>
    public class BasketUrlValueResolver : DittoValueResolver
    {
        /// <summary>
        /// The basket URL.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            return ContentResolver.Instance.GetBasketContent().Url;
        }
    }
}