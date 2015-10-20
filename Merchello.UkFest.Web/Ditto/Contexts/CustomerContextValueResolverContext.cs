namespace Merchello.UkFest.Web.Ditto.Contexts
{
    using System;

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
        /// The <see cref="IBasketSalePreparation"/>.
        /// </summary>
        private Lazy<IBasketSalePreparation> _preparation;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerContextValueResolverContext"/> class.
        /// </summary>
        public CustomerContextValueResolverContext()
        {
            this.Initialize();
        }

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
        public IBasketSalePreparation SalePreparation
        {
            get
            {
                return _preparation.Value;
            }
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        private void Initialize()
        {
            _preparation = new Lazy<IBasketSalePreparation>(() => Basket.SalePreparation());
        }
    }
}