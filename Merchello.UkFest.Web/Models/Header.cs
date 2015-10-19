using System.Web;

namespace Merchello.UkFest.Web.Models
{
    using Our.Umbraco.Ditto;

    /// <summary>
    /// The category header.
    /// </summary>
    public class Header
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [UmbracoProperty("Title", "Name")]
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the brief.
        /// </summary>
        [UmbracoProperty("Brief", "HeadDescription")]
        public IHtmlString Brief { get; set; } 
    }
}