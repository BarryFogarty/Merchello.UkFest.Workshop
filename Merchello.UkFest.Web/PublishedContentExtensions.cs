namespace Merchello.UkFest.Web
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.UkFest.Web.Models;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// Utility IPublishedContent extensions.
    /// </summary>
    public static class PublishedContentExtensions
    {
        /// <summary>
        /// The get image from cropper.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <param name="cropperAlias">
        /// The cropper alias.
        /// </param>
        /// <returns>
        /// The <see cref="IPublishedContent"/>.
        /// </returns>
        public static IPublishedContent GetImageFromCropper(this IPublishedContent content, string cropperAlias)
        {
            return content.WillWork(cropperAlias) ? content.GetPropertyValue<IPublishedContent>(cropperAlias) : null;
        }

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
        /// Maps <see cref="IPublishedContent"/> to <see cref="Link"/>.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <returns>
        /// The <see cref="Link"/>.
        /// </returns>
        public static Link AsLink(this IPublishedContent content)
        {
            return new Link { Title = content.Name, Url = content.Url };
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
            return content.Children.Where(x => x.IsVisible());
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
    }
}