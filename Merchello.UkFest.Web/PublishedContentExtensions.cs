using Umbraco.Web.Models;

namespace Merchello.UkFest.Web
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.UkFest.Web.Models;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// Utility IPublishedContent extensions.
    /// </summary>
    public static class PublishedContentExtensions
    {
        
        /// <summary>
        /// Determines if a property exists and if it has a value.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool WillWork(this IPublishedContent content, string propertyAlias)
        {
            return content.HasProperty(propertyAlias) && content.HasValue(propertyAlias);
        }

        /// <summary>
        /// The visible children.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<IPublishedContent> VisibleChildren(this IPublishedContent content)
        {
            return content.Children != null ? content.Children.Where(x => x.IsVisible()) : Enumerable.Empty<IPublishedContent>();
        }

        /// <summary>
        /// As above but iterating through all descendants.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<IPublishedContent> VisibleDescendants(this IPublishedContent content)
        {
            return content.Descendants() != null ? content.Descendants().Where(x => x.IsVisible()) : Enumerable.Empty<IPublishedContent>();
        }

        /// <summary>
        /// The visible children.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="IPublishedContent"/>
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IEnumerable<T> VisibleChildren<T>(this IPublishedContent content) 
            where T : class, IPublishedContent
        {
            return content.Children<T>().Where(x => x.IsVisible());
        }


        /// <summary>
        /// Sets a default value on a content entity
        /// Used by the content_saving event to populate content auto-properties
        /// NB: Strictly speaking this is a Content extension, not IPublishedContent - refactor to own class if there will be others
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="alias"></param>
        /// <param name="defaultValue"></param>
        public static void SetDefaultValue(this IContent entity, string alias, string defaultValue)
        {
            if (entity.HasProperty(alias) && string.IsNullOrWhiteSpace(entity.GetValue<string>(alias)))
            {
                entity.SetValue(alias, defaultValue);
            }
        }


        public static string GetCrop(this IPublishedContent publishedContent, int? width = null, int? height = null, ImageCropMode? cropMode = null) //ImageCropRatioMode? ratioMode = null
        {
            return publishedContent.GetCropUrl(width, height, imageCropMode: cropMode, furtherOptions: string.Format("&bgcolor={0}", AppSettings.CropBackgroundColour));
        }

        public static string GetCrop(this string imageUrl, int? width = null, int? height = null, ImageCropMode? cropMode = null)
        {
            return imageUrl.GetCropUrl(width, height, imageCropMode: cropMode, furtherOptions: string.Format("&bgcolor={0}", AppSettings.CropBackgroundColour));
        }


    }
}