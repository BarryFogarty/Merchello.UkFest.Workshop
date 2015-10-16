namespace Merchello.UkFest.Web.Ditto.ValueResolvers
{
    using System;

    using Merchello.Core;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Logging;

    /// <summary>
    /// The product collection name value resolver.
    /// </summary>
    /// <remarks>
    /// Assumes the property name is "products"
    /// </remarks>
    public class ProductCollectionNameValueResolver : DittoValueResolver
    {
        /// <summary>
        /// Gets the name of the products entity collection.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ResolveValue()
        {

            if (Content == null) return string.Empty;
            if (!Content.WillWork("products")) return string.Empty;
            var collectionKey = new Guid(Content.GetProperty("products").DataValue.ToString());

            var collection = MerchelloContext.Current.Services.EntityCollectionService.GetByKey(collectionKey);
            if (collection == null)
            {
                var nullRef = new NullReferenceException("Product collection EntityCollection was not found");
                LogHelper.Error<ProductCollectionNameValueResolver>("Product collection was null", nullRef);
                throw nullRef;
            }

            return collection.Name;
        }
    }
}