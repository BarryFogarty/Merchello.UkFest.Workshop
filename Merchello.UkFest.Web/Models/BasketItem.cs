namespace Merchello.UkFest.Web.Models
{
    using System;

    /// <summary>
    /// A model representing Basket line items.
    /// </summary>
    public class BasketItem : ProductLineItem
    {
        /// <summary>
        /// Gets or sets the product key.
        /// </summary>
        public Guid ProductKey { get; set; }

        /// <summary>
        /// Gets or sets the product url.
        /// </summary>
        public string ProductUrl { get; set; }
    }
}