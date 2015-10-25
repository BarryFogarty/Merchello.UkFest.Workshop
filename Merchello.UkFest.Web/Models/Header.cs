using System.Web;
using Our.Umbraco.Ditto;

namespace Merchello.UkFest.Web.Models
{
    [UmbracoProperties(Prefix = "Head")]
    public class Header
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the brief.
        /// </summary>
        public IHtmlString Description { get; set; }
    }
}
