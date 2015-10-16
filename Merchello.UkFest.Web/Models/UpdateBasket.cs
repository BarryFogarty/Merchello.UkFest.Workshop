namespace Merchello.UkFest.Web.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// A model used for updating a basket.
    /// </summary>
    public class UpdateBasket
    {
        /// <summary>
        /// Gets or sets the continue shopping url.
        /// </summary>
        public string ContinueShoppingUrl { get; set; }

        /// <summary>
        /// Gets or sets the checkout url.
        /// </summary>
        public string CheckoutUrl { get; set; }

        /// <summary>
        /// Gets or sets the formatted basket total.
        /// </summary>
        public string FormattedBasketTotal { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public IEnumerable<BasketItem> Items { get; set; }
    }
}