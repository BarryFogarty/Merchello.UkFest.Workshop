using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merchello.UkFest.Web.Ditto.ValueResolvers;
using Our.Umbraco.Ditto;

namespace Merchello.UkFest.Web.Models
{
    public class ProductListing
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        [DittoValueResolver(typeof(ProductListItemsValueResolver))]
        public virtual IEnumerable<ProductListItem> Products { get; set; }
    }
}
