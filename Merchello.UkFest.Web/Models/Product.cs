using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Merchello.UkFest.Web.Ditto.ValueResolvers;
using Our.Umbraco.Ditto;

namespace Merchello.UkFest.Web.Models
{
    public class Product
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public IHtmlString Text { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        public virtual IEnumerable<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether on sale.
        /// </summary>
        public bool OnSale { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is new.
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// Gets or sets the add to basket.
        /// </summary>
        [DittoValueResolver(typeof(AddToBasketValueResolver))]
        public AddToBasket AddToBasket { get; set; }

    }
}
