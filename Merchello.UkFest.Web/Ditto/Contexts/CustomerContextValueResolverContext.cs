namespace Merchello.UkFest.Web.Ditto.Contexts
{
    using Merchello.Core.Models;
    using Merchello.Web;
    using Merchello.Web.Pluggable;
    using Merchello.Web.Workflow;

    using Our.Umbraco.Ditto;

    using Umbraco.Core;
    using Umbraco.Core.Cache;
    using Umbraco.Web;

    /// <summary>
    /// A context for basket related values
    /// </summary>
    public class CustomerContextValueResolverContext : DittoValueResolverContext
    {
        /// <summary>
        /// The Request cache.
        /// </summary>
        private readonly ICacheProvider _requestCache = ApplicationContext.Current.ApplicationCache.RequestCache;

        /// <summary>
        /// Gets the <see cref="ICustomerContext"/>.
        /// </summary>
        public ICustomerContext CustomerContext
        {
            get
            {
                return (ICustomerContext)_requestCache
                    .GetCacheItem(
                    "CustomerContext",
                    () => PluggableObjectHelper.GetInstance<CustomerContextBase>("CustomerContext", UmbracoContext.Current));
            }
        }

        /// <summary>
        /// Gets the current customer.
        /// </summary>
        public ICustomerBase CurrentCustomer
        {
            get
            {
                return CustomerContext.CurrentCustomer;
            }
        }

        /// <summary>
        /// Gets the basket.
        /// </summary>
        public IBasket Basket
        {
            get
            {
                return CurrentCustomer.Basket();
            }
        }

        /// <summary>
        /// Gets the sale preparation.
        /// </summary>
        public BasketSalePreparation SalePreparation
        {
            get
            {
                return Basket.SalePreparation();
            }
        }
    }
}