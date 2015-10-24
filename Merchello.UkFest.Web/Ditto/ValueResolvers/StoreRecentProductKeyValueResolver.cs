namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System;

    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.Web.Models.VirtualContent;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// Retrieves the product key and updates the recently viewed context.
    /// TODO: Workshop: simplify so it just returns product Key (maybe just unbind this resolver?)
    /// </summary>
    public class StoreRecentProductKeyValueResolver : DittoValueResolver<RecentlyViewedValueResolverContext>
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Guid.Empty;

            var product = Content as IProductContent;
            if (product == null) return Guid.Empty;

            // Updates the recently viewed context
            Context.AddRecentProduct(product);

            return product.Key;
        }
    }
}