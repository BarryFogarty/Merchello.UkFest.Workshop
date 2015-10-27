namespace Merchello.UkFest.Web.Models.PublishedContent
{
    using System.Web;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;
    using Umbraco.Core.Models.PublishedContent;

    /// <summary>
    /// The category.
    /// </summary>
    public class CategoryNavItem : PublishedContentModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryNavItem"/> class.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        public CategoryNavItem(IPublishedContent content)
            : base(content)
        {
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public Image Image { get; set; }

    }
}