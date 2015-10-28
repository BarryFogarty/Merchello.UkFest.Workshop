namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.UkFest.Web.Models;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// Resolves category sub category products lists.
    /// </summary>
    public class CategoryProductListValueResolver : CategoryProductListingBaseValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{ProductListItem}"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<ProductListItem>();

            var productListings = Content.VisibleDescendants().Where(x => x.DocumentTypeAlias == "SubCategory").Select(x => x.As<ProductListing>());

            foreach (var prodList in productListings)
            {
                AddRange(prodList.Products);
            }

            return PagedCollection;
        }
    }
}