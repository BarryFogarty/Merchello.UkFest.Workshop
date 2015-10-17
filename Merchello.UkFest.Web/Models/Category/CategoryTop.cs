namespace Merchello.UkFest.Web.Models.Category
{
    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The category top.
    /// </summary>
    public class CategoryTop
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        [DittoValueResolver(typeof(CategoryTopProductListValueResolver))]
        public PagedCollection<ProductListItem> Pager { get; set; } 
    }
}