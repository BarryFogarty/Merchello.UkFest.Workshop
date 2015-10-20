namespace Merchello.UkFest.Web.Models.Checkout
{
    using System;

    /// <summary>
    /// Represents a shipment rate quote.
    /// </summary>
    public class DeliveryQuote
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        public string Rate { get; set; }

        /// <summary>
        /// Gets or sets the method name.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }
}