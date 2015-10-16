namespace Merchello.UkFest.Web.Models
{
    using System;

    /// <summary>
    /// A model items in a product list.
    /// </summary>
    public class ProductListItem : IStoreProduct
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the product image source.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the formatted price.
        /// </summary>
        public string FormattedPrice { get; set; }

        /// <summary>
        /// Gets or sets the formatted sale price.
        /// </summary>
        public string FormattedSalePrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether on sale.
        /// </summary>
        public bool OnSale { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is new.
        /// </summary>
        public bool IsNew { get; set; }
    }
}