namespace Merchello.UkFest.Web.Models.DitFlo
{
    using System.Collections.Generic;
    using System.Globalization;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;
    using Umbraco.Web.Models;

    /// <summary>
    /// Base class for DitFlo view models.
    /// </summary>
    public abstract class BaseDitFloViewModel : RenderModel, IDitFloViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDitFloViewModel"/> class.
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
        protected BaseDitFloViewModel(
            IPublishedContent content, 
            CultureInfo culture = null, 
            IEnumerable<DittoValueResolverContext> valueResolverContexts = null)
            : base(content, culture)
        {
            this.ValueResolverContexts = valueResolverContexts ?? new List<DittoValueResolverContext>();
        }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        public IPublishedContent CurrentPage
        {
            get
            {
                return this.Content;
            }
        }

        /// <summary>
        /// Gets or sets the value resolver contexts.
        /// </summary>
        internal IEnumerable<DittoValueResolverContext> ValueResolverContexts { get; set; }
    }
}