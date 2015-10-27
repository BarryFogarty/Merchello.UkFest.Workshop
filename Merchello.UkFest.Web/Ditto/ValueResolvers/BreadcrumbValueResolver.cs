namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Linq;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// The breadcrumb value resolver.
    /// </summary>
    public class BreadcrumbValueResolver : DittoValueResolver
    {
        /// <summary>
        /// Resolves the bread crumb.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<IPublishedContent>();

            return Content.AncestorsOrSelf().Reverse();
        }
    }
}