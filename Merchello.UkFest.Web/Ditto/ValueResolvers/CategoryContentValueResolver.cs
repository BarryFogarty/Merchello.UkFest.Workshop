namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Linq;

    using Merchello.UkFest.Web.Resolvers;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;

    /// <summary>
    /// Resolves thee category content nodes.
    /// </summary>
    public class CategoryContentValueResolver : DittoValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<IPublishedContent>();

            var root = ContentResolver.Instance.GetRootContent();

            return root.VisibleChildren().Where(x => x.ContentType.Alias == "Category").OrderBy(x => x.SortOrder);
        }
    }
}