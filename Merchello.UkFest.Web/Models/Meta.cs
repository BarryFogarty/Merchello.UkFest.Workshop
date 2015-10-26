using System.ComponentModel;
using System.Web;
using Merchello.UkFest.Web.Ditto.TypeConverters;
using Our.Umbraco.Ditto;

namespace Merchello.UkFest.Web.Models
{
    [UmbracoProperties(Prefix = "Head")]
    public class Meta
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [UmbracoProperty("HeadTitle", "Name")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the brief.
        /// </summary>
        [TypeConverter(typeof(MetaDescriptionConverter))]
        public string Description { get; set; }
    }
}
