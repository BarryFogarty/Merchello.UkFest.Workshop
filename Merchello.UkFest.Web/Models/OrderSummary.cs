namespace Merchello.UkFest.Web.Models
{
    using System.Collections.Generic;

    using Merchello.Core.Models;

    /// <summary>
    /// A model for the order summary.
    /// </summary>
    public class OrderSummary
    {
        /// <summary>
        /// Gets or sets the shipping information.
        /// </summary>
        public string ShippingInfo { get; set; }

        /// <summary>
        /// Gets or sets the formatted sub total.
        /// </summary>
        public string FormattedSubTotal { get; set; }

        /// <summary>
        /// Gets or sets the formatted shipping total.
        /// </summary>
        public string FormattedShippingTotal { get; set; }

        /// <summary>
        /// Gets or sets the total title.
        /// </summary>
        public string TotalTitle { get; set; }

        /// <summary>
        /// Gets or sets the formatted total.
        /// </summary>
        public string FormattedTotal { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public IEnumerable<ILineItem> Items { get; set; } 
    }
}