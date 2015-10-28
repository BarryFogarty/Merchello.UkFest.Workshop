using System.Collections.Generic;
using System.Linq;
using Merchello.UkFest.Web.Models;
using Merchello.UkFest.Web.Models.Category;
using Merchello.UkFest.Web.Resolvers;
using Our.Umbraco.Ditto;

namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    public class CategoryTreeItemValueResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<CategoryTreeItem>();

            var topLevel = ContentResolver.Instance.GetStoreCategoryContent().VisibleChildren();

            return topLevel.Select(item => new CategoryTreeItem
                    {
                        CategoryLink = item.As<Link>(), 
                        SubLinks = item.VisibleChildren().As<Link>()
                    });
        }
    }
}
