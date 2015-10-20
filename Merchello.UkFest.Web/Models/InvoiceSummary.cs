namespace Merchello.UkFest.Web.Models
{
    using System.Collections.Generic;

    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The order review.
    /// </summary>
    public class InvoiceSummary
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        [DittoValueResolver(typeof(ProductLineItemsValueResolver))]
        public IEnumerable<ProductLineItem> Products { get; set; }

        /// <summary>
        /// Gets or sets the formatted total.
        /// </summary>
        [DittoValueResolver(typeof(CollectionTotalValueResolver))]
        public string FormattedTotal { get; set; }
    }
}