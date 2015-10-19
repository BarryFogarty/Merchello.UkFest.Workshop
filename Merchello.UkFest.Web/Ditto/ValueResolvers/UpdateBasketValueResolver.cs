namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Linq;

    using Merchello.Core.Models;
    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.UkFest.Web.Models;
    using Merchello.UkFest.Web.Resolvers;
    using Merchello.Web;
    using Merchello.Web.Workflow;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// Creates an UpdateBasket value.
    /// </summary>
    public class UpdateBasketValueResolver : DittoValueResolver<CustomerContextValueResolverContext>
    {
        /// <summary>
        /// The <see cref="MerchelloHelper"/>.
        /// </summary>
        private readonly MerchelloHelper _merchello = new MerchelloHelper();

        /// <summary>
        /// Maps <see cref="IBasket"/> from customer context to UpdateBasket model.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return new UpdateBasket();
            var basket = Context.Basket;
            var contentResolver = ContentResolver.Instance;

            return new UpdateBasket
                {
                    ContinueShoppingUrl = contentResolver.GetRootContent().Url,
                    CheckoutUrl = contentResolver.GetCheckoutContent().Url,
                    FormattedBasketTotal = StoreHelper.FormatCurrency(basket.TotalBasketPrice),
                    Items = basket.Items.Select(x => ((IItemCacheLineItem)x).AsBasketItem(_merchello)).ToArray()
                };
        }
    }
}