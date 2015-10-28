using System.Collections.Generic;
using Merchello.UkFest.Web.Ditto.ValueResolvers;
using Our.Umbraco.Ditto;

namespace Merchello.UkFest.Web.Models.Category
{
    public class CategoryTree
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        [DittoValueResolver(typeof(CategoryTreeItemValueResolver))]
        public IEnumerable<CategoryTreeItem> Items { get; set; }
    }
}
