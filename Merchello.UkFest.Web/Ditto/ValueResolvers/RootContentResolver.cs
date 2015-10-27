namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Resolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// A value resolver for the website's root node.
    /// </summary>
    public class RootContentResolver : DittoValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            return ContentResolver.Instance.GetRootContent();
        }
    }
}