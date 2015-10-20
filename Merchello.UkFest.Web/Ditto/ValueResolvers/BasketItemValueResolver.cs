namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Linq;

    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.Web;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The basket item value resolver.
    /// </summary>
    public class BasketItemValueResolver : DittoValueResolver<CustomerContextValueResolverContext>
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            var merchello = new MerchelloHelper();
            return Context.Basket.Items.Select(x => x.AsBasketItem(merchello));
        }
    }
}