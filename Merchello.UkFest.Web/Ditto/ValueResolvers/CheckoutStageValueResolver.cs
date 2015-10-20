namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Ditto.Contexts;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// Resolves the maximum validated checkout stage.
    /// </summary>
    public class CheckoutStageValueResolver : DittoValueResolver<CheckoutStageResolverContext>
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            return Context.Stage;
        }
    }
}