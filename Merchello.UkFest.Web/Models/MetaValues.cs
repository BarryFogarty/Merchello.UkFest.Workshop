using Our.Umbraco.Ditto;

namespace Merchello.UkFest.Web.Models
{
    /// <summary>
    /// The meta values.
    /// </summary>
    public class MetaValues
    {
        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        [UmbracoProperty("MetaTitle", "Name")]
        public string MetaTitle { get; set; }

        /// <summary>
        /// Gets or sets the Meta description.
        /// </summary>
        public string MetaDescription { get; set; }
    }
}