namespace Merchello.UkFest.Web.Models.Account
{
    using System;
    using System.Collections.Generic;

    using Merchello.UkFest.Web.Models.Checkout;

    /// <summary>
    /// A customer order.
    /// </summary>
    public class CustomerOrder 
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the invoice date.
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets the invoice status.
        /// </summary>
        public string InvoiceStatus { get; set; }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public IEnumerable<BasketItem> Products { get; set; }

        /// <summary>
        /// Gets or sets the formatted sub total.
        /// </summary>
        public string FormattedSubTotal { get; set; }

        /// <summary>
        /// Gets or sets the formatted shipping total.
        /// </summary>
        public string FormattedShippingTotal { get; set; }

        /// <summary>
        /// Gets or sets the formatted discount total.
        /// </summary>
        public string FormattedDiscountTotal { get; set; }

        /// <summary>
        /// Gets or sets the formatted total.
        /// </summary>
        public string FormattedTotal { get; set; }

        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        public AddressModel BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        public AddressModel ShippingAddress { get; set; }
    }
}