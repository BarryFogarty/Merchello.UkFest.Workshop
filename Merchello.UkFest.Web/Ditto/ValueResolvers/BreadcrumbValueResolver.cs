namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.UkFest.Web.Models;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// The breadcrumb value resolver.
    /// </summary>
    public class BreadcrumbValueResolver : DittoValueResolver
    {
        /// <summary>
        /// Resolves the bread crumb.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<Link>();

            var list = new List<Link>();
            var current = Content;
            while (current.Parent != null)
            {
                list.Add(current.AsLink());
                current = current.Parent;
            }

            list.Add(current.AsLink());

            list.Reverse();
            return list;
        }
    }
}