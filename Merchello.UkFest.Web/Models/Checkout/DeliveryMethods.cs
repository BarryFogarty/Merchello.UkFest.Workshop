namespace Merchello.UkFest.Web.Models.Checkout
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The delivery methods.
    /// </summary>
    public class DeliveryMethod : CheckoutStageBase
    {
        /// <summary>
        /// Gets or sets the ship method key.
        /// </summary>
        public Guid ShipMethodKey { get; set; }

        /// <summary>
        /// Gets or sets the quotes.
        /// </summary>
        public IEnumerable<DeliveryQuote> Quotes { get; set; } 
    }
}