namespace Merchello.UkFest.Web.Resolvers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using Umbraco.Core;
    using Umbraco.Core.Logging;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Umbraco.Web.Routing;

    /// <summary>
    /// A base class for content resolvers.
    /// </summary>
    internal abstract class ContentResolverBase
    {
        /// <summary>
        /// The content reference hash.
        /// </summary>
        private static readonly ConcurrentDictionary<int, int> ContentHash = new ConcurrentDictionary<int, int>();


        /// <summary>
        /// Gets the <see cref="UmbracoContext"/>.
        /// </summary>
        protected static UmbracoContext UmbracoContext
        {
            get
            {
                if (UmbracoContext.Current == null)
                {
                    var nullReference = new NullReferenceException("UmbracoContext was null");
                    LogHelper.Error<ContentResolverBase>("The ContentResolver requires a current UmbracoContext", nullReference);
                    throw nullReference;
                }

                return UmbracoContext.Current;
            }
        }

        /// <summary>
        /// Removes hash references to ids.
        /// </summary>
        /// <param name="ids">
        /// The ids.
        /// </param>
        internal void RemoveByIds(IEnumerable<int> ids)
        {
            ids.ForEach(this.RemoveById);
        }

        /// <summary>
        /// The remove reference.
        /// </summary>
        /// <param name="id">
        /// The content id.
        /// </param>
        internal void RemoveById(int id)
        {
            //// Remove all references to the id
            foreach (var key in ContentHash.Where(x => x.Value == id).Select(x => x.Key))
            {
                int value;
                ContentHash.TryRemove(key, out value);
            }
        }

        /// <summary>
        /// Attempts to get a unique page from contextual cache based on a alias reference hash.
        /// </summary>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="getter">
        /// A function to retrieve the content if the reference is not found.
        /// </param>
        /// <returns>
        /// The <see cref="IPublishedContent"/>.
        /// </returns>
        internal IPublishedContent GetByAlias(string alias, Func<IPublishedContent> getter)
        {
            var hashCode = GetAliasBaseHashCode(alias);
            if (ContentHash.ContainsKey(hashCode)) return GetFromContextualCache(ContentHash[hashCode]);

            var content = getter.Invoke();
            if (content == null)
            {
                LogAndThrow(string.Format("No IPublishedContent found for GetByAlias getter Func with alias {0}", alias), string.Format("Could not find {0} aliased content node", alias));
            }

            StashAsAliased(alias, content);

            return content;
        }

        /// <summary>
        /// Attempts to get a unique page from contextual cache based on a unique content type reference hash.
        /// </summary>
        /// <param name="contentTypeAlias">
        /// The content type alias.
        /// </param>
        /// <param name="getter">
        /// The getter.
        /// </param>
        /// <returns>
        /// The <see cref="IPublishedContent"/>.
        /// </returns>
        protected static IPublishedContent TryGetUniquePageContent(string contentTypeAlias, Func<IPublishedContent> getter)
        {
            var hashCode = GetUniquePageHashCode(contentTypeAlias);
            if (ContentHash.ContainsKey(hashCode)) return GetFromContextualCache(ContentHash[hashCode]);

            var content = getter.Invoke();
            if (content == null)
            {
                LogAndThrow(string.Format("No IPublishedContent found for {0}", contentTypeAlias), string.Format("Could not find {0} content node", contentTypeAlias));
            }

            StashAsUnique(content);

            return content;
        }

        /// <summary>
        /// Attempts to get content from contextual cache based on a URL based reference hash.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="getter">
        /// The getter.
        /// </param>
        /// <returns>
        /// The <see cref="IPublishedContent"/>.
        /// </returns>
        protected static IPublishedContent TryGetUrlBasedContent(string url, Func<IPublishedContent> getter)
        {
            var hashCode = GetUrlBasedHashCode(url);
            if (ContentHash.ContainsKey(hashCode)) return GetFromContextualCache(ContentHash[hashCode]);

            var content = getter.Invoke();

            // Cannot throw here as other content finders may find the content.
            if (content == null) return null;

            StashAsUrlBased(content);

            return content;
        }


        /// <summary>
        /// Gets the <see cref="IPublishedContent"/> from contextual cache or null.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IPublishedContent"/>.
        /// </returns>
        /// <remarks>
        /// This will throw a logged exception if the UmbracoContext is null.
        /// </remarks>
        protected static IPublishedContent GetFromContextualCache(int? id)
        {
            return id != null ? UmbracoContext.ContentCache.GetById(id.Value) : null;
        }

        /// <summary>
        /// Gets a hash code for a unique type of content. e.g. Website, Checkout, Cart
        /// </summary>
        /// <param name="contentTypeAlias">
        /// The content type alias.
        /// </param>
        /// <returns>
        /// The hash code.
        /// </returns>
        protected static int GetUniquePageHashCode(string contentTypeAlias)
        {
            return contentTypeAlias.GetHashCode();
        }

        /// <summary>
        /// Gets an alias based HashCode.
        /// </summary>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <remarks>
        /// Aliases should be unique across all sites
        /// </remarks>
        protected static int GetAliasBaseHashCode(string alias)
        {
            return alias.GetHashCode();
        }

        /// <summary>
        /// Gets a hash code for a URL based content lookups.  e.g. Used in FRS custom <see cref="IContentFinder"/>s
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected static int GetUrlBasedHashCode(string url)
        {
            return string.Format("slug:{0}", url.EnsureNotStartsOrEndsWith('/')).GetHashCode();
        }

        /// <summary>
        /// Stores a reference to a unique page of content. e.g. Website, Cart, Checkout
        /// </summary>
        /// <param name="content">
        /// The content to be referenced.
        /// </param>
        private static void StashAsUnique(IPublishedContent content)
        {
            if (content == null) return;

            var hashCode = GetUniquePageHashCode(content.ContentType.Alias);

            Stash(hashCode, content.Id);
        }

        /// <summary>
        /// Stores a reference to content that by a UNIQUE alias.
        /// </summary>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="content">
        /// The content to be referenced.
        /// </param>
        private static void StashAsAliased(string alias, IPublishedContent content)
        {
            if (content == null) return;

            var hashCode = GetAliasBaseHashCode(alias);

            Stash(hashCode, content.Id);
        }

        /// <summary>
        /// Stores a URL based reference to a page of content.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        private static void StashAsUrlBased(IPublishedContent content)
        {
            if (content == null) return;

            var hashCode = GetUrlBasedHashCode(content.Url);

            Stash(hashCode, content.Id);
        }

        /// <summary>
        /// Stashes the reference to the content in the dictionary.
        /// </summary>
        /// <param name="hashCode">
        /// The hash code.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        private static void Stash(int hashCode, int id)
        {
            if (ContentHash.ContainsKey(hashCode))
            {
                LogHelper.Debug<ContentResolverBase>("Hash code was already found for Unique content type.  Overwritting value");
            }

            ContentHash.AddOrUpdate(hashCode, id, (x, y) => id);
        }

        /// <summary>
        /// Logs an exception to the log file and throws a null reference exception.
        /// </summary>
        /// <param name="nullRefMessage">
        /// The message for the null reference exception.
        /// </param>
        /// <param name="loggerMessage">
        /// The message for the <see cref="LogHelper"/>.
        /// </param>
        /// <exception cref="NullReferenceException">
        /// Throws the null reference exception
        /// </exception>
        private static void LogAndThrow(string nullRefMessage, string loggerMessage)
        {
            var nullReference = new NullReferenceException(nullRefMessage);
            LogHelper.Error<ContentResolverBase>(loggerMessage, nullReference);
            throw nullReference;
        }
    }
}