namespace Merchello.UkFest.Web.Ditto.Contexts
{
    using Merchello.Web.Pluggable;

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
        /// Gets the <see cref="ICustomerContext"/>.
        /// </summary>
        public ICustomerContext CustomerContext
        {
            get
            {
                return _customerContext;
            }
        }
    }
}