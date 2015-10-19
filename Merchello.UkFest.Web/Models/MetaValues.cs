using System.ComponentModel;
using Merchello.UkFest.Web.Ditto.TypeConverters;
using Our.Umbraco.Ditto;

namespace Merchello.UkFest.Web.Models
{
    /// <summary>
    /// The meta values.
    /// </summary>
    //[UmbracoProperties(Prefix = "Head")]
    public class MetaValues
    {
        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        [UmbracoProperty("HeadTitle", "Name")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Meta description.
        /// </summary>
        [TypeConverter(typeof(MetaDescriptionConverter))]
        [UmbracoProperty("HeadDescription", "Name")]
        public string Description { get; set; }
    }
}