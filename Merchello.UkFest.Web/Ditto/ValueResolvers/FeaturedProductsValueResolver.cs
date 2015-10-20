using Merchello.UkFest.Web.Resolvers;

namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.UkFest.Web.Models;
    using Merchello.Web.Models.VirtualContent;

    using Our.Umbraco.Ditto;

    using Umbraco.Web;

    /// <summary>
    /// A resolver for product listings.
    /// </summary>
    public class FeaturedProductsValueResolver : DittoValueResolver
    {
        /// <summary>
        /// Resolves the <see cref="ProductListing"/> from Merchello's <see cref="IEnumerable{IProductContent}"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            var empty = Enumerable.Empty<ProductListItem>();

            if (Content == null) return empty;

            var root = ContentResolver.Instance.GetRootContent();

            var featuredProducts = root.GetPropertyValue<IEnumerable<IProductContent>>("featuredProducts");

            if (featuredProducts == null || !featuredProducts.Any()) return empty;

            return featuredProducts.Take(3).Select(x => x.AsProductListItem());
        }
    }
}