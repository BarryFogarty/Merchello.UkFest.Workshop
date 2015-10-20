namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Resolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// A resolver for the continue shopping URL.
    /// </summary>
    public class ContinueShoppingUrlValueResolver : DittoValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            return ContentResolver.Instance.GetRootContent().Url;
        }
    }
}