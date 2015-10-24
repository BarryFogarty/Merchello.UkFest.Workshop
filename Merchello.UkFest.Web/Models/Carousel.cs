namespace Merchello.UkFest.Web.Models
{
    using System.Collections.Generic;

    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The carousel.
    /// </summary>
    public class Carousel
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        [DittoValueResolver(typeof(CarouselItemsResolver))]
        public virtual IEnumerable<CarouselItem> Items { get; set; }  
    }
}