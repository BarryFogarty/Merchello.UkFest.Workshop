using System.Web;

namespace Merchello.UkFest.Web.Models
{
    public class TextPage
    {
        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body text
        /// </summary>
        public IHtmlString Text { get; set; }

    }
}
