namespace Merchello.UkFest.Web
{
    using System;

    using Merchello.Core;
    using Merchello.Core.Models;
    using Merchello.Core.Models.Interfaces;
    using Merchello.Core.Services;

    /// <summary>
    /// A utility helper class for store related operations.
    /// </summary>
    public static class StoreHelper
    {
        /// <summary>
        /// Merchello's <see cref="IStoreSettingService"/>.
        /// </summary>
        /// <remarks>
        /// This is lazy to prevent problems with application bootstrapping
        /// </remarks>
        private static readonly Lazy<IStoreSettingService> StoreSettingService = new Lazy<IStoreSettingService>(() => MerchelloContext.Current.Services.StoreSettingService);

        /// <summary>
        /// The store currency.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private static ICurrency _storeCurrency;

        /// <summary>
        /// The currency format.
        /// </summary>
        // ReSharper disable InconsistentNaming
        private static ICurrencyFormat _currencyFormat;

        /// <summary>
        /// Gets the store currency.
        /// </summary>
        public static ICurrency StoreCurrency
        {
            get
            {
                if (_storeCurrency != null) return _storeCurrency;
                var storeSetting = StoreSettingService.Value.GetByKey(Merchello.Core.Constants.StoreSettingKeys.CurrencyCodeKey);
                _storeCurrency = StoreSettingService.Value.GetCurrencyByCode(storeSetting.Value);
                return _storeCurrency;
            }
        }

        /// <summary>
        /// Gets the store currency format.
        /// </summary>
        private static ICurrencyFormat StoreCurrencyFormat
        {
            get
            {
                if (_currencyFormat != null) return _currencyFormat;
                _currencyFormat = StoreSettingService.Value.GetCurrencyFormat(StoreCurrency);
                return _currencyFormat;
            }
        }

        /// <summary>
        /// Formats the currency based with symbol and configured culture.
        /// </summary>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <returns>
        /// The formatted amount.
        /// </returns>
        /// <remarks>
        /// Overrides for currency format are made in the Merchello.config
        /// </remarks>
        public static string FormatCurrency(decimal amount)
        {
            return string.Format(StoreCurrencyFormat.Format, _storeCurrency.Symbol, amount);
        }
    }
}