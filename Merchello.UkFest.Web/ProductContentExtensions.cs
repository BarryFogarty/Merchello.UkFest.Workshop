using Umbraco.Core;

namespace Merchello.UkFest.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.Core.Models;
    using Merchello.UkFest.Web.Models;
    using Merchello.UkFest.Web.Models.Api;
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

        /// <summary>
        /// Maps <see cref="IProductContent"/> to <see cref="ModalProduct"/>.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The <see cref="ModalProduct"/>.
        /// </returns>
        public static ModalProduct AsModalProduct(this IProductContent product)
        {
            var choices = product.ProductOptions.Any() ?
                    product.ProductOptions.First()
                    .Choices.Select(x => new Tuple<string, string>(x.Key.ToString(), x.Name)) :
                    Enumerable.Empty<Tuple<string, string>>();
           
            return new ModalProduct
                       {
                           Key = product.Key,
                           Name = product.Name,
                           Url = product.Url,
                           Price = StoreHelper.FormatCurrency(product.Price),
                           SalePrice = StoreHelper.FormatCurrency(product.SalePrice),
                           OnSale = product.OnSale,
                           IsNew = product.WillWork("isNew") && product.GetPropertyValue<bool>("isNew"),
                           Images =
                               product.WillWork("images")
                                   ? product.GetPropertyValue<IEnumerable<IPublishedContent>>("images")
                                         .Select(x => x.Url)
                                   : Enumerable.Empty<string>(),
                           PossibleChoices = choices,
                           Description = product.WillWork("text") 
                                            ? product.GetPropertyValue<string>("text").StripHtml()
                                            : string.Empty
                       };
        }
    }
}