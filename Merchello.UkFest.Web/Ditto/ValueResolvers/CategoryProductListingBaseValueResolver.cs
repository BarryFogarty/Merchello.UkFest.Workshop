namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.UkFest.Web.Models;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The category product listing base value resolver.
    /// </summary>
    public abstract class CategoryProductListingBaseValueResolver : DittoValueResolver<CategoryPagerResolverContext>
    {
        /// <summary>
        /// The products.
        /// </summary>
        private readonly List<ProductListItem> _products = new List<ProductListItem>();

        /// <summary>
        /// Gets the paged collection.
        /// </summary>
        internal PagedCollection<ProductListItem> PagedCollection
        {
            get
            {
               return new PagedCollection<ProductListItem>
                {
                    CurrentPage = Context.CurrentPage,
                    TotalItems = _products.Count(),
                    PageSize = Context.ItemsPerPage,
                    Items =
                        Products.Skip((int)(Context.CurrentPage - 1) * Context.ItemsPerPage)
                        .Take(this.Context.ItemsPerPage),
                    TotalPages = (int)Math.Ceiling(_products.Count / (decimal)Context.ItemsPerPage),
                    SortField = Context.SortBy
                };
            }
        } 

        /// <summary>
        /// Gets the collection of products.
        /// </summary>
        private IEnumerable<ProductListItem> Products
        {
            get
            {
                return Context.SortBy == "Name"
                                 ? _products.OrderBy(x => x.Name).ToList()
                                 : _products.OrderByDescending(x => x.Price).ToList();
            }
        }

        /// <summary>
        /// Adds a distinct list of product list items.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        internal void AddRange(IEnumerable<ProductListItem> items)
        {
            _products.AddRange(items.Where(prod => _products.All(exist => exist.Key != prod.Key)));
        }

    }
}