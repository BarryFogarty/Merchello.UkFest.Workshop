using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchello.UkFest.Web.Models.Category
{
    public class CategoryTreeItem
    {
        /// <summary>
        /// Gets or sets the category link.
        /// </summary>
        public Link CategoryLink { get; set; }

        /// <summary>
        /// Gets or sets the sub links.
        /// </summary>
        public IEnumerable<Link> SubLinks { get; set; }
    }
}
