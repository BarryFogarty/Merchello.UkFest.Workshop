namespace Merchello.UkFest.Web.Models
{
    using System.Collections.Generic;

    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;

    /// <summary>
    /// A model for the top navigation.
    /// </summary>
    public class NavBar
    {
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        //[DittoValueResolver(typeof(CategoryContentValueResolver))]
        //public IEnumerable<IPublishedContent> Categories { get; set; }

        [DittoValueResolver(typeof(NavBarValueResolver))]
        public virtual IEnumerable<IPublishedContent> Menu { get; set; }

        /// <summary>
        /// Gets or sets the site branding information.
        /// </summary>
        /// <remarks>
        /// Cannot use recursive properties here due to IPublishedProduct (virtual content)
        /// </remarks>
        [DittoValueResolver(typeof(BrandingValueResolver))]
        public Branding Branding { get; set; }

        /// <summary>
        /// Gets or sets the link to the basket.
        /// </summary>
        [DittoValueResolver(typeof(BasketLinkResolver))]
        public Link BasketLink { get; set; }

        /// <summary>
        /// Gets or sets the basket item count.
        /// </summary>
        [DittoValueResolver(typeof(BasketItemCountResolver))]
        public int BasketItemCount { get; set; }
 
    }
}