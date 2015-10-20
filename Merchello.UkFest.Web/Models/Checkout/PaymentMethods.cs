namespace Merchello.UkFest.Web.Models.Checkout
{
    using System;
    using System.Collections.Generic;

    using Merchello.Core.Models;

    /// <summary>
    /// Payment method selection.
    /// </summary>
    public class PaymentMethods : CheckoutStageBase
    {
        /// <summary>
        /// Gets or sets the selected payment method.
        /// </summary>
        public Guid SelectedPaymentMethod { get; set; }

        /// <summary>
        /// Gets or sets the methods.
        /// </summary>
        public IEnumerable<IPaymentMethod> Methods { get; set; } 
    }
}