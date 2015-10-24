namespace Merchello.UkFest.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The product detail.
    /// </summary>
    public class ProductDetail : IStoreProduct
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        //[DittoValueResolver(typeof(StoreRecentProductKeyValueResolver))]
        public Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [UmbracoProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [UmbracoProperty("Text")]
        public IHtmlString Description { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        public virtual IEnumerable<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        [UmbracoProperty("Url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether on sale.
        /// </summary>
        [UmbracoProperty("OnSale")]
        public bool OnSale { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is new.
        /// </summary>
        [UmbracoProperty("isNew")]
        public bool IsNew { get; set; }

        /// <summary>
        /// Gets or sets the add to basket.
        /// TODO: workshop: Unbind or simplify (no product options perhaps)
        /// </summary>
        [DittoValueResolver(typeof(AddToBasketValueResolver))]
        public AddToBasket AddToBasket { get; set; }
    }
}