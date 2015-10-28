namespace Merchello.UkFest.Web.Models
{
    using System;

    /// <summary>
    /// The product base.
    /// </summary>
    public interface IStoreProduct
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the product url.
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is on sale.
        /// </summary>
        bool OnSale { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is new.
        /// </summary>
        bool IsNew { get; set; }
    }
}