namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.UkFest.Web.Models;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The category top product list value resolver.
    /// </summary>
    public class CategoryTopProductListValueResolver : CategoryProductListingBaseValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <remarks>
        /// This is going to get slow with large collections of products.
        /// </remarks>
        public override object ResolveValue()
        {
            if (Content == null) return null;


            var categories = Content.VisibleChildren().Where(x => x.DocumentTypeAlias == "Category");
            foreach (var prodList in 
                categories
                .SelectMany(
                    category => 
                        category.VisibleChildren()
                        .Where(x => x.DocumentTypeAlias == "SubCategory").Select(sub => sub.As<ProductListing>())))
            {
                AddRange(prodList.Products);
            }

            return PagedCollection;
        }
    }
}