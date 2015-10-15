namespace Merchello.UkFest.Web.Models.DitFlo
{
    using System.Collections.Generic;
    using System.Globalization;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;

    /// <summary>
    /// The DitFlow view model (generic IPublishedContent)
    /// </summary>
    public class DitFloViewModel : DitFloViewModel<IPublishedContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DitFloViewModel"/> class.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <param name="valueResolverContexts">
        /// The value resolver contexts.
        /// </param>
        protected DitFloViewModel(
            IPublishedContent content,
            CultureInfo culture = null,
            IEnumerable<DittoValueResolverContext> valueResolverContexts = null)
            : base(content, culture, valueResolverContexts)
        {            
        }
    }
}