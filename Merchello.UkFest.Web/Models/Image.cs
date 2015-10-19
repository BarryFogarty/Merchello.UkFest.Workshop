using System.ComponentModel;
using Our.Umbraco.Ditto;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using umbConstants = Umbraco.Core.Constants.Conventions;

namespace Merchello.UkFest.Web.Models
{
    [TypeConverter(typeof(DittoPickerConverter))]
    public class Image : PublishedContentModel
    {
        public Image(IPublishedContent content)
            : base(content)
        {
        }

        [UmbracoProperty(umbConstants.Media.Bytes)]
        public int Bytes { get; set; }

        [UmbracoProperty(umbConstants.Media.Width)]
        public int Width { get; set; }

        [UmbracoProperty(umbConstants.Media.Height)]
        public int Height { get; set; }

        [UmbracoProperty(umbConstants.Media.Extension)]
        public string Extension { get; set; }
    }
}
