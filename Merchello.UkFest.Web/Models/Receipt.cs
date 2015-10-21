namespace Merchello.UkFest.Web.Models
{
    using Merchello.UkFest.Web.Ditto.ValueResolvers;
    using Merchello.UkFest.Web.Models.Account;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The receipt.
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// Gets or sets the customer order.
        /// </summary>
        [DittoValueResolver(typeof(CustomerOrderValueResolver))]
        public CustomerOrder CustomerOrder { get; set; } 
    }
}