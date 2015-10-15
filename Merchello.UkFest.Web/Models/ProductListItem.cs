namespace Merchello.UkFest.Web.Models
{
    /// <summary>
    /// A model items in a product list.
    /// </summary>
    public class ProductListItem
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the product image source.
        /// </summary>
        public string ImageSrc { get; set; }

        /// <summary>
        /// Gets or sets the formatted price.
        /// </summary>
        public string FormattedPrice { get; set; }

        /// <summary>
        /// Gets or sets the formatted sale price.
        /// </summary>
        public string FormattedSalePrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is on sale.
        /// </summary>
        public bool OnSale { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is new.
        /// </summary>
        public bool IsNew { get; set; }
    }
}