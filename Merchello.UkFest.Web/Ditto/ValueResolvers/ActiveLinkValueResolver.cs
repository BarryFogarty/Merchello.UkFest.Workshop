﻿namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using Our.Umbraco.Ditto;

    using Umbraco.Web;

    /// <summary>
    /// The active link value resolver.
    /// </summary>
    public class ActiveLinkValueResolver : DittoValueResolver
    {
        /// <summary>
        /// The resolve value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {
            if (Content == null) return false;

            return Content.Path.Contains(UmbracoContext.Current.PageId.ToString());
        }
    }
}