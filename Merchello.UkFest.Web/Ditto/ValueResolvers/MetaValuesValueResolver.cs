namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Models;
    using Merchello.UkFest.Web.Resolvers;

    using Our.Umbraco.Ditto;

    using Umbraco.Web;

    /// <summary>
    /// The meta values value resolver.
    /// </summary>
    public class MetaValuesValueResolver : DittoValueResolver
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
            var root = ContentResolver.Instance.GetRootContent();

            return new MetaValues
                       {
                           MetaTitle = root.GetPropertyValue<string>("pageTitle"),
                           MetaDescription = root.GetPropertyValue<string>("metaDescription")
                       };
        }
    }
}