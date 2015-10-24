using System.Web;
using Merchello.UkFest.Web.Ditto.ValueResolvers;
using Our.Umbraco.Ditto;

namespace Merchello.UkFest.Web.Models
{
    /// <summary>
    /// The meta values.
    /// </summary>
    public class TextPage
    {
        
        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        [UmbracoProperty("Title", "Name")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body text
        /// </summary>
        public IHtmlString Text { get; set; }
    }
}