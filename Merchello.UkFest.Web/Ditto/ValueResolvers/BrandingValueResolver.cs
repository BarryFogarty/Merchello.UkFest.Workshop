namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Models;
    using Merchello.UkFest.Web.Resolvers;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// A resolver for site branding values.
    /// </summary>
    public class BrandingValueResolver : DittoValueResolver
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
            var branding = new Branding
                {
                    CompanyName = root.GetPropertyValue<string>("companyName"),
                    Logo = root.GetPropertyValue<IPublishedContent>("logo"),
                    LogoSmall = root.GetPropertyValue<IPublishedContent>("logoSmall")
                };

            return branding;
        }
    }
}