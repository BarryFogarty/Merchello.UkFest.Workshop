namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Linq;

    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.UkFest.Web.Models;
    using Merchello.Web;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The recently viewed value resolver.
    /// </summary>
    public class RecentlyViewedValueResolver : DittoValueResolver<RecentlyViewedValueResolverContext>
    {
        /// <summary>
        /// The <see cref="MerchelloHelper"/>.
        /// </summary>
        private readonly MerchelloHelper _merchello = new MerchelloHelper();

        /// <summary>
        /// Resolves the recently view products and returns a recent list per user.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<ProductListItem>();

            return Context.Keys.Select(x => _merchello.TypedProductContent(x).AsProductListItem());
        }
    }
}