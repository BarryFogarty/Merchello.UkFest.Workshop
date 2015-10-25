using System.Web;

namespace Merchello.UkFest.Web.Models
{
    public class Header
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string HeadTitle { get; set; }

        /// <summary>
        /// Gets or sets the brief.
        /// </summary>
        public IHtmlString HeadDescription { get; set; }
    }
}
