namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Linq;

    using Merchello.UkFest.Web.Resolvers;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;

    /// <summary>
    /// Resolves thee category content nodes.
    /// </summary>
    public class NavBarValueResolver : DittoValueResolver
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

            // get a list of visible children from the root, plus the root (home) itself.  Is SortOrder the default sort?  if not, .OrderBy(x => x.SortOrder)
            var menuItems = new[] {root}.Union(root.VisibleChildren());

            return menuItems;
        }
    }
}