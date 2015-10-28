namespace Merchello.UkFest.Web.Models.Api
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The modal product.
    /// </summary>
    public class ModalProduct
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
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        public IEnumerable<string> Images { get; set; } 

        /// <summary>
        /// Gets or sets the possible choices.
        /// </summary>
        public IEnumerable<Tuple<string, string>> PossibleChoices { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Gets or sets the sale price.
        /// </summary>
        public string SalePrice { get; set; }

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