namespace Merchello.UkFest.Web.Models
{
    using System;

    /// <summary>
    /// A model representing Basket line items.
    /// </summary>
    public class BasketItem
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the product key.
        /// </summary>
        public Guid ProductKey { get; set; }

        /// <summary>
        /// Gets or sets the product url.
        /// </summary>
        public string ProductUrl { get; set; }

        /// <summary>
        /// Gets or sets the formatted price.
        /// </summary>
        public string FormattedPrice { get; set; }

        /// <summary>
        /// Gets or sets the formatted unit price.
        /// </summary>
        public string FormattedUnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}