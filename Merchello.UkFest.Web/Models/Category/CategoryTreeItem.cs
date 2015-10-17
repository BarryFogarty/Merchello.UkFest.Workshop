namespace Merchello.UkFest.Web.Models.Category
{
    using System.Collections.Generic;

    /// <summary>
    /// The category tree item.
    /// </summary>
    public class CategoryTreeItem
    {
        /// <summary>
        /// Gets or sets the category link.
        /// </summary>
        public Link CategoryLink { get; set; }

        /// <summary>
        /// Gets or sets the product count.
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// Gets or sets the sub links.
        /// </summary>
        public IEnumerable<Link> SubLinks { get; set; } 
    }
}