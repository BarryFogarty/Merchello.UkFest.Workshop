namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Ditto.Contexts;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The basket total value resolver.
    /// </summary>
    public class CollectionTotalValueResolver : DittoValueResolver<CustomerContextValueResolverContext>
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            return StoreHelper.FormatCurrency(!this.Context.SalePreparation.IsReadyToInvoice() ? 
                this.Context.Basket.TotalBasketPrice : 
                this.Context.SalePreparation.PrepareInvoice().Total);
        }
    }
}