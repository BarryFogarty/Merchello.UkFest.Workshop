namespace Merchello.UkFest.Web.Models
{
    using System.Collections.Generic;

    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The recently view collection.
    /// </summary>
    public class FeaturedProducts
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [UmbracoDictionary("FeaturedProducts")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        [DittoValueResolver(typeof(FeaturedProductsValueResolver))]
        public IEnumerable<ProductListItem> Products { get; set; }
    }
}