namespace Merchello.UkFest.Web.Models
{
    using System.Collections.Generic;

    using Merchello.UkFest.Web.Ditto.ValueResolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The breadcrumb.
    /// </summary>
    public class Breadcrumb
    {
        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        [DittoValueResolver(typeof(BreadcrumbValueResolver))]
        public virtual IEnumerable<Link> Links { get; set; } 
    }
}