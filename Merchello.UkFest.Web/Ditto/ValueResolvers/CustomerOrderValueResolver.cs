namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System;

    using Merchello.Core;
    using Merchello.UkFest.Web.Ditto.Contexts;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The customer order value resolver.
    /// </summary>
    public class CustomerOrderValueResolver : DittoValueResolver<ReceiptValueResolverContext>
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            var key = Context.InvoiceKey;
            if (key.Equals(Guid.Empty)) return null;

            var invoice = MerchelloContext.Current.Services.InvoiceService.GetByKey(key);

            return invoice.AsCustomerOrder();
        }
    }
}