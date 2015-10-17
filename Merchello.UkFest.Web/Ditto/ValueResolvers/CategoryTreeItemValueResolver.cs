namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Linq;

    using Merchello.UkFest.Web.Models;
    using Merchello.UkFest.Web.Models.Category;
    using Merchello.UkFest.Web.Resolvers;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// Resolves the surf category tree.
    /// </summary>
    public class CategoryTreeItemValueResolver : DittoValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<CategoryTreeItem>();

            var top = ContentResolver.Instance.GetSurfCategoryContent();
            var treeItems = top.VisibleChildren()
                .Select(category => 
                    new CategoryTreeItem
                        {
                            CategoryLink = category.As<Link>(), 
                            ProductCount = category.VisibleChildren().Select(x => x.As<ProductListing>()).Sum(x => x.Products.Count()),
                            SubLinks = category.VisibleChildren().Select(x => x.As<Link>())
                        });

            return treeItems;
        }
    }
}