namespace Merchello.UkFest.Web.Models
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
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the url target.
        /// </summary>
        [DittoValueResolver(typeof(UrlTargetResolver))]
        public string Target { get; set; }
    } 
}
