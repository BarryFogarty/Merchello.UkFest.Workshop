namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Merchello.UkFest.Web.Models;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The URL target resolver.
    /// </summary>
    public class UrlTargetResolver : DittoValueResolver
    {
        /// <summary>
        /// Resolves the target of a <see cref="Link"/>.
        /// </summary>
        /// <returns>
        /// The string representing the link target.
        /// </returns>
        public override object ResolveValue()
        {
            if (this.Content == null) return null;

            return this.Content.Url.StartsWith("/") ? "_self" : "_blank";
        }
    }
}