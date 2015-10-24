namespace Merchello.UkFest.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// A model for the Add to Basket form.
    /// </summary>
    public class AddToBasket
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddToBasket"/> class.
        /// </summary>
        public AddToBasket()
        {
             
        }

        /// <summary>
        /// Gets or sets the product key.
        /// </summary>
        [UmbracoProperty("Key")]
        public Guid ProductKey { get; set; }

        /// <summary>
        /// Gets or sets the formatted price.
        /// </summary>
        [DittoValueResolver(typeof(FormattedPriceValueResolver))]
        public string FormattedPrice { get; set; }

        /// <summary>
        /// Gets or sets the formatted sale price.
        /// </summary>
        [DittoValueResolver(typeof(FormattedSalePriceValueResolver))]
        public string FormattedSalePrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is on sale.
        /// </summary>
        [UmbracoProperty("OnSale")]
        public bool OnSale { get; set; }
    }
}