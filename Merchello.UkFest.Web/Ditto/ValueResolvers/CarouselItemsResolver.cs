namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.UkFest.Web.Models;
    using Merchello.Web.Models.VirtualContent;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// Resolves the carousel items.
    /// </summary>
    public class CarouselItemsResolver : DittoValueResolver
    {
        /// <summary>
        /// Resolves the carousel items.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<CarouselItem>();

            var products = Content.GetPropertyValue<IEnumerable<IProductContent>>("carousel");

            return
                products.Select(
                    x =>
                    new CarouselItem
                        {
                            ImageUrl =
                                x.GetPropertyValue<IEnumerable<IPublishedContent>>("images").First()
                                .GetCropUrl(width: 450, height: 450),
                            Url = x.Url
                        });
        }
    }
}