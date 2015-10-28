namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Linq;

    using Merchello.Core.Models;
    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.Web;

    using Our.Umbraco.Ditto;

    using Umbraco.Core;

    /// <summary>
    /// The product line items value resolver.
    /// </summary>
    public class ProductLineItemsValueResolver : DittoValueResolver<CustomerContextValueResolverContext>
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            var merchello = new MerchelloHelper();
            return !this.Context.SalePreparation.IsReadyToInvoice() ? 
                this.Context.Basket.Items.Select(x => x.AsProductLineItem(merchello)) :
                this.Context.SalePreparation.PrepareInvoice().ProductLineItems().Select(x => x.AsProductLineItem(merchello));
        }
    }
}