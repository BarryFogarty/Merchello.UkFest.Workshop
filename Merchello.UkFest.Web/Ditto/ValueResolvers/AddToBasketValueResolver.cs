namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Models;
    using Merchello.Web.Models.VirtualContent;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// Creates an Add to Basket model.
    /// </summary>
    public class AddToBasketValueResolver : DittoValueResolver
    {
        /// <summary>
        /// Maps <see cref="IProductContent"/> to <see cref="AddToBasket"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return new AddToBasket();
            var product = Content as IProductContent;
            if (product == null) return new AddToBasket();

            return product.As<AddToBasket>();
        }
    }
}