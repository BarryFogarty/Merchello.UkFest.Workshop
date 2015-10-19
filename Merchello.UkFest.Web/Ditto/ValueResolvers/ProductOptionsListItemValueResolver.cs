namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Linq;
    using System.Web.Mvc;

    using Merchello.Web.Models.VirtualContent;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The product options list item value resolver.
    /// </summary>
    public class ProductOptionsListItemValueResolver : DittoValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<SelectListItem>();

            var product = Content as IProductContent;
            if (product == null) return Enumerable.Empty<SelectListItem>();
            if (!product.ProductOptions.Any()) return Enumerable.Empty<SelectListItem>();

            var option = product.ProductOptions.First();

            return option.Choices.Select(
                x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Key.ToString()
                });
        }
    }
}