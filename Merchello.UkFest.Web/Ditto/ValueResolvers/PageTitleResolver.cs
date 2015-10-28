namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Our.Umbraco.Ditto;

    using Umbraco.Web;

    /// <summary>
    /// Ditto resolver for a page title.
    /// </summary>
    public class PageTitleResolver : DittoValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            return this.Content == null ?
                string.Empty :
                Content.WillWork("pageTitle")
                           ? Content.GetPropertyValue<string>("pageTitle")
                           : Content.Name;
        }
    }
}