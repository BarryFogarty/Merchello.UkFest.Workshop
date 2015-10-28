using Merchello.UkFest.Web.Models;

namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Collections.Generic;
    using System.Linq;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// The product images value resolver.
    /// </summary>
    public class ProductImagesValueResolver : DittoValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<string>();
            if (!Content.WillWork("images")) return Enumerable.Empty<string>();

            return Content.GetPropertyValue<IEnumerable<Image>>("images");
        }
    }
}