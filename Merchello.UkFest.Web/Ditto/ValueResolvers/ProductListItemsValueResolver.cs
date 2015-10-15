namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.Core;
    using Merchello.UkFest.Web.Models;
    using Merchello.Web.Models.VirtualContent;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Logging;
    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// A resolver for product listings.
    /// </summary>
    public class ProductListItemsValueResolver : DittoValueResolver
    {
        /// <summary>
        /// Resolves the <see cref="ProductListing"/> from Merchello's <see cref="IEnumerable{IProductContent}"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            var empty = Enumerable.Empty<ProductListItem>();

            if (Content == null) return empty;
            if (!Content.WillWork("products")) return empty;

            var products = Content.GetPropertyValue<IEnumerable<IProductContent>>("products");

            return products.Select(x => new ProductListItem
                {
                    Name = x.Name,
                    FormattedPrice = StoreHelper.FormatCurrency(x.Price),
                    FormattedSalePrice = StoreHelper.FormatCurrency(x.SalePrice),
                    OnSale = x.OnSale,
                    IsNew = x.WillWork("isNew") && x.GetPropertyValue<bool>("isNew"),
                    ImageSrc = x.WillWork("images") ? x.GetPropertyValue<IEnumerable<IPublishedContent>>("images").First().GetCropUrl(255,255) : string.Empty
                });
        }
    }
}