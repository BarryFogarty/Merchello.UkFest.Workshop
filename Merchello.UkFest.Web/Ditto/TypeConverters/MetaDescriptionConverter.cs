using System;
using System.ComponentModel;
using System.Globalization;
using System.Web;
using Our.Umbraco.Ditto;
using Umbraco.Core;

namespace Merchello.UkFest.Web.Ditto.TypeConverters
{

    public class MetaDescriptionConverter : DittoConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType == typeof(HtmlString) || sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return value != null ? value.ToString().StripHtml().ReplaceNewLines(" ").TruncateAtWord(160) : string.Empty;
        }
    }
}
