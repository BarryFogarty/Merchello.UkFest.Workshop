namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System;
    using System.Linq;

    using Merchello.Web.Models.VirtualContent;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The option choice value resolver.
    /// </summary>
    public class OptionChoiceValueResolver : DittoValueResolver
    {
        /// <summary>
        /// Resolves the first choice of the first option.
        /// </summary>
        /// <returns>
        /// The GUID key.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Guid.Empty;

            var product = Content as IProductContent;
            if (product == null) return Guid.Empty;

            return !product.ProductOptions.Any() ? Guid.Empty : product.ProductOptions.First().Choices.First().Key;
        }
    }
}