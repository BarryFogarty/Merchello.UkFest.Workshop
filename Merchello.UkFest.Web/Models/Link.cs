﻿namespace Merchello.UkFest.Web.Models
{
    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The link.
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [UmbracoProperty("Name")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [UmbracoProperty("Url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the url target.
        /// </summary>
        [DittoValueResolver(typeof(UrlTargetResolver))]
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        [DittoValueResolver(typeof(ActiveLinkValueResolver))]
        public bool IsActive { get; set; }

        public string ActiveCss()
        {
            return this.IsActive ? "class=\"active\"" : string.Empty;
        }
    } 
}
