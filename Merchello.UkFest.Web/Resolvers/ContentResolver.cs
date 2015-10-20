namespace Merchello.UkFest.Web.Resolvers
{
    using System.Linq;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// A resolver to find Content.
    /// </summary>
    internal class ContentResolver : ContentResolverBase
    {
        /// <summary>
        /// The root XPATH.
        /// </summary>
        /// <remarks>
        /// Used in GetRootContent()
        /// </remarks>
        private const string RootXpath = "//root/Home";

        /// <summary>
        /// Singleton instance of the resolver. 
        /// </summary>
        private static readonly ContentResolver Resolver = new ContentResolver();

        /// <summary>
        /// Prevents a default instance of the <see cref="ContentResolver"/> class from being created.
        /// </summary>
        private ContentResolver()
        {
        }

        /// <summary>
        /// Gets the singleton instance of the resolver.
        /// </summary>
        internal static ContentResolver Instance
        {
            get
            {
                return Resolver;
            }
        }

        /// <summary>
        /// Gets the site root content.
        /// </summary>
        /// <returns>
        /// The <see cref="IPublishedContent"/>.
        /// </returns>
        internal IPublishedContent GetRootContent()
        {
            return TryGetUniquePageContent(
                "Home",
                () =>
                {
                    var umbraco = new UmbracoHelper(UmbracoContext);
                    return umbraco.TypedContentSingleAtXPath(RootXpath);
                });
        }

        /// <summary>
        /// Gets the Basket content page.
        /// </summary>
        /// <returns>
        /// The <see cref="IPublishedContent"/>.
        /// </returns>
        internal IPublishedContent GetBasketContent()
        {
            return TryGetUniquePageContent(
                "Basket",
                () =>
                {
                    var root = this.GetRootContent();
                    return root.Descendant("Basket");
                });
        }

        /// <summary>
        /// Gets the checkout content.
        /// </summary>
        /// <returns>
        /// The <see cref="IPublishedContent"/>.
        /// </returns>
        internal IPublishedContent GetCheckoutContent()
        {
            return TryGetUniquePageContent(
                "Checkout",
                () =>
                    {
                        var basket = this.GetBasketContent();
                        return basket.FirstChild();
                    });
        }

        /// <summary>
        /// The get store category content.
        /// </summary>
        /// <returns>
        /// The <see cref="IPublishedContent"/>.
        /// </returns>
        internal IPublishedContent GetStoreCategoryContent()
        {
            return this.GetByAlias(
                "Store",
                () =>
                    {
                        var root = this.GetRootContent();
                        return root.Descendants("Category").FirstOrDefault();
                    });
        }
    }
}