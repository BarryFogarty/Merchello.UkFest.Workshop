﻿namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.Web;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The basket item count resolver.
    /// </summary>
    public class BasketItemCountResolver : DittoValueResolver<CustomerContextValueResolverContext>
    {
        /// <summary>
        /// Resolves the basket item count.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return 0;
            return Context.CustomerContext.CurrentCustomer.Basket().TotalQuantityCount;
        }
    }
}