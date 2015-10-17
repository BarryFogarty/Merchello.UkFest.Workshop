namespace Merchello.UkFest.Web.Models.Category
{
    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The category.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the sub categories.
        /// </summary>
        [DittoValueResolver(typeof(CategoryProductListValueResolver))]
        public PagedCollection<ProductListItem> Pager { get; set; } 
    }
}