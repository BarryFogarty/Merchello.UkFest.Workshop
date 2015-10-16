namespace Merchello.UkFest.Web.Ditto.Contexts
{
    using System;

    using Merchello.Web;
    using Merchello.Web.Pluggable;
    using Merchello.Web.Workflow;

    using Our.Umbraco.Ditto;

    using Umbraco.Web;

    /// <summary>
    /// A context for basket related values
    /// </summary>
    public class CustomerContextValueResolverContext : DittoValueResolverContext
    {
        /// <summary>
        /// The <see cref="ICustomerContext"/>.
        /// </summary>
        private readonly ICustomerContext _customerContext = PluggableObjectHelper.GetInstance<CustomerContextBase>("CustomerContext", UmbracoContext.Current);

        /// <summary>
        /// The <see cref="IBasket"/>
        /// </summary>
        private Lazy<IBasket> _basket;

        /// <summary>
        /// The <see cref="BasketSalePreparation"/>.
        /// </summary>
        private Lazy<BasketSalePreparation> _preparation; 

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
                return _customerContext;
            }
        }

        /// <summary>
        /// Gets the basket.
        /// </summary>
        public IBasket Basket
        {
            get
            {
                return _basket.Value;
            }
        }

        /// <summary>
        /// Gets the sale preparation.
        /// </summary>
        public BasketSalePreparation SalePreparation
        {
            get
            {
                return _preparation.Value;
            }
        }

        /// <summary>
        /// Initializes the context.
        /// </summary>
        private void Initialize()
        {
            _basket = new Lazy<IBasket>(() => CustomerContext.CurrentCustomer.Basket());
            _preparation = new Lazy<BasketSalePreparation>(() => _basket.Value.SalePreparation());
        }
    }
}