using System.Collections.Generic;
using System.Web;
using Our.Umbraco.Ditto;

namespace Merchello.UkFest.Web.Models
{
    [UmbracoProperties(Prefix = "Promo")]
    public class Promo
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public IHtmlString Text { get; set; }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        public Image Image { get; set; }
    }
}