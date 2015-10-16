namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Merchello.Web.Models.VirtualContent;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The formatted price value resolver.
    /// </summary>
    public class FormattedPriceValueResolver : DittoValueResolver
    {
        /// <summary>
        /// Resolves the price.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return StoreHelper.FormatCurrency(0);
            var product = Content as IProductContent;
            if (product == null) throw new Exception("Formatted price resolver can only be used with IProductContent models");

            return StoreHelper.FormatCurrency(product.Price);
        }
    }

    /// <summary>
    /// The formatted sale price value resolver.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public class FormattedSalePriceValueResolver : DittoValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return StoreHelper.FormatCurrency(0);
            var product = Content as IProductContent;
            if (product == null) throw new Exception("Formatted price resolver can only be used with IProductContent models");

            return StoreHelper.FormatCurrency(product.SalePrice);
        }
    }
}