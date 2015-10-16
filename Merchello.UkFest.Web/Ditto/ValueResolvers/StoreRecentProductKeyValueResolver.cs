namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System;

    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.Web.Models.VirtualContent;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// Retrieves the product key and updates the recently viewed context.
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
            Context.AddRecentProduct(product);

            return product.Key;
        }
    }
}