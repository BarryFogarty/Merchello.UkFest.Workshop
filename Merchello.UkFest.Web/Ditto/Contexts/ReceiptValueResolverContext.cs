namespace Merchello.UkFest.Web.Ditto.Contexts
{
    using System;

    using Umbraco.Core;

    /// <summary>
    /// A receipt value resolver.
    /// </summary>
    public class ReceiptValueResolverContext : CustomerContextValueResolverContext
    {
        /// <summary>
        /// The invoice key.
        /// </summary>
        private Guid _invoiceKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptValueResolverContext"/> class.
        /// </summary>
        public ReceiptValueResolverContext()
        {
            this.Initialize();
        }

        /// <summary>
        /// Gets the invoice key.
        /// </summary>
        public Guid InvoiceKey
        {
            get
            {
                return _invoiceKey;
            }
        }

        /// <summary>
        /// The set value.
        /// </summary>
        /// <param name="invoiceKey">
        /// The invoice key.
        /// </param>
        public void SetValue(Guid invoiceKey)
        {
            CustomerContext.SetValue("ikey", invoiceKey.ToString());
        }

        /// <summary>
        /// Initializes the context.
        /// </summary>
        private void Initialize()
        {
            var value = CustomerContext.GetValue("ikey");
            _invoiceKey = value.IsNullOrWhiteSpace() ? Guid.Empty : new Guid(value);
        }
    }
}