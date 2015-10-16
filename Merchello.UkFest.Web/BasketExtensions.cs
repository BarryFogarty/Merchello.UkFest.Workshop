namespace Merchello.UkFest.Web
{
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.Core.Models;
    using Merchello.UkFest.Web.Models;
    using Merchello.Web;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// Basket related extension methods.
    /// </summary>
    public static class BasketExtensions
    {
        /// <summary>
        /// Maps <see cref="IItemCacheLineItem"/> to <see cref="BasketItem"/>.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="merchello">
        /// The <see cref="MerchelloHelper"/>.
        /// </param>
        /// <returns>
        /// The <see cref="BasketItem"/>.
        /// </returns>
        public static BasketItem AsBasketItem(this IItemCacheLineItem item, MerchelloHelper merchello)
        {
            if (!item.ExtendedData.ContainsProductKey()) return null;
            var product = merchello.TypedProductContent(item.ExtendedData.GetProductKey());
            if (product == null) return null;

            var images = product.GetPropertyValue<IEnumerable<IPublishedContent>>("images").ToArray();

            return new BasketItem
                       {
                           FormattedUnitPrice = StoreHelper.FormatCurrency(item.Price),
                           FormattedPrice = StoreHelper.FormatCurrency(item.TotalPrice),
                           Image = images.Any() ? images.First().Url : string.Empty,
                           Key = product.Key,
                           Name = item.Name,
                           ProductUrl = product.Url,
                           Quantity = item.Quantity
                       };
        }
    }
}