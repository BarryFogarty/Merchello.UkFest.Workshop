﻿namespace Merchello.UkFest.Web
{
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.Core;
    using Merchello.Core.Gateways.Shipping;
    using Merchello.Core.Models;
    using Merchello.UkFest.Web.Models;
    using Merchello.UkFest.Web.Models.Checkout;
    using Merchello.Web;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// Store related extension methods.
    /// </summary>
    public static class StoreExtensions
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
                           Key = item.Key,
                           FormattedUnitPrice = StoreHelper.FormatCurrency(item.Price),
                           FormattedPrice = StoreHelper.FormatCurrency(item.TotalPrice),
                           Image = images.Any() ? images.First().GetCropUrl(50, 50) : string.Empty,
                           ProductKey = product.Key,
                           Name = item.Name,
                           ProductUrl = product.Url,
                           Quantity = item.Quantity
                       };
        }

        /// <summary>
        /// Maps <see cref="IAddress"/> to <see cref="AddressModel"/>.
        /// </summary>
        /// <param name="adr">
        /// The address.
        /// </param>
        /// <returns>
        /// The <see cref="AddressModel"/>.
        /// </returns>
        public static AddressModel AsAddressModel(this IAddress adr)
        {
            return new AddressModel
                       {
                           FirstName = adr.TrySplitFirstName(),
                           LastName = adr.TrySplitLastName(),
                           Address1 = adr.Address1,
                           Address2 = adr.Address2,
                           Locality = adr.Locality,
                           PostalCode = adr.PostalCode,
                           CountryCode = adr.CountryCode,
                           Email = adr.Email,
                           Phone = adr.Phone
                       };
        }

        /// <summary>
        /// Maps <see cref="AddressModel"/> to <see cref="IAddress"/>.
        /// </summary>
        /// <param name="adr">
        /// The address.
        /// </param>
        /// <param name="addressType">
        /// The address type.
        /// </param>
        /// <returns>
        /// The <see cref="IAddress"/>.
        /// </returns>
        public static IAddress AsAddress(this AddressModel adr, AddressType addressType)
        {
            return new Address
                       {
                           Name = string.Format("{0} {1}", adr.FirstName, adr.LastName),
                           Address1 = adr.Address1,
                           Address2 = adr.Address2,
                           Locality = adr.Locality,
                           PostalCode = adr.PostalCode,
                           CountryCode = adr.CountryCode,
                           Email = adr.Email,
                           Phone = adr.Phone,
                           AddressType = addressType
                       };
        }

        /// <summary>
        /// Maps <see cref="IShipmentRateQuote"/> to <see cref="DeliveryQuote"/>.
        /// </summary>
        /// <param name="quote">
        /// The quote.
        /// </param>
        /// <returns>
        /// The <see cref="DeliveryQuote"/>.
        /// </returns>
        public static DeliveryQuote AsDeliveryQuote(this IShipmentRateQuote quote)
        {
            return new DeliveryQuote
                       {
                           Key = quote.ShipMethod.Key,
                           Rate = StoreHelper.FormatCurrency(quote.Rate),
                           Description = quote.ShipMethod.Name == "Ground" ? "Standard delivery" : "Get it quick",
                           MethodName = quote.ShipMethod.Name
                       };
        }
    }
}