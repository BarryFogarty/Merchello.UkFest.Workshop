namespace Merchello.UkFest.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.Core.Models;
    using Merchello.UkFest.Web.Models;
    using Merchello.Web.Models.VirtualContent;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// Extension methods for <see cref="IProductContent"/>.
    /// </summary>
    public static class ProductContentExtensions
    {
        /// <summary>
        /// Maps <see cref="IProductContent"/> to <see cref="ProductListItem"/>.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The <see cref="ProductListItem"/>.
        /// </returns>
        public static ProductListItem AsProductListItem(this IProductContent product)
        {
            return new ProductListItem
                       {
                           Key = product.Key,
                           Name = product.Name,
                           Url = product.Url,
                           FormattedPrice = StoreHelper.FormatCurrency(product.Price),
                           FormattedSalePrice = StoreHelper.FormatCurrency(product.SalePrice),
                           OnSale = product.OnSale,
                           IsNew = product.WillWork("isNew") && product.GetPropertyValue<bool>("isNew"),
                           ImageUrl =
                               product.WillWork("images")
                                   ? product.GetPropertyValue<IEnumerable<IPublishedContent>>("images")
                                         .First()
                                         .GetCropUrl(255, 255)
                                   : string.Empty,
                            Price = product.OnSale ? product.SalePrice : product.Price
                       };
        }

        
    }
}