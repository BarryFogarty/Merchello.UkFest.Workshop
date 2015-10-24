namespace Merchello.UkFest.Web.Models
{
    using System.Collections.Generic;

    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The recently view collection.
    /// </summary>
    public class RecentlyViewed
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [UmbracoDictionary("RecentlyViewed")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        [DittoValueResolver(typeof(RecentlyViewedValueResolver))]
        public virtual IEnumerable<ProductListItem> Products { get; set; }
    }
}