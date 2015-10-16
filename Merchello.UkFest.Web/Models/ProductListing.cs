namespace Merchello.UkFest.Web.Models
{
    using System.Collections.Generic;
    using System.Web;

    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// A model for product listings.
    /// </summary>
    public class ProductListing
    {
        /// <summary>
        /// Gets or sets the collection name.
        /// </summary>
        [DittoValueResolver(typeof(ProductCollectionNameValueResolver))]
        public string CollectionName { get; set; }

        /// <summary>
        /// Gets or sets the collection brief.
        /// </summary>
        [UmbracoProperty("collectionBrief")]
        public IHtmlString CollectionBrief { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        [DittoValueResolver(typeof(ProductListItemsValueResolver))]
        public IEnumerable<ProductListItem> Products { get; set; } 
    }
}