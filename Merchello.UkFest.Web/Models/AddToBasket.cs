namespace Merchello.UkFest.Web.Models
{
    using System;
    using System.Collections.Generic;

    using Merchello.UkFest.Web.Ditto.ValueResolvers;
    using Merchello.Web.Models.ContentEditing;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// A model for the Add to Basket form.
    /// </summary>
    public class AddToBasket
    {
        /// <summary>
        /// Gets or sets the product key.
        /// </summary>
        [UmbracoProperty("Key")]
        public Guid ProductKey { get; set; }

        /// <summary>
        /// Gets or sets the option choices (if there are any), used to determine the variant 
        /// in post back
        /// </summary>
        public Guid[] OptionChoices { get; set; }

        /// <summary>
        /// Gets or sets the product options.
        /// </summary>
        /// <remarks>
        /// This will be empty if the product does not have variants
        /// </remarks>
        [UmbracoProperty("ProductOptions")]
        public IEnumerable<ProductOptionDisplay> ProductOptions { get; set; }

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