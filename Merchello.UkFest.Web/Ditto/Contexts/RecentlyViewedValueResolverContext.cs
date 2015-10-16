namespace Merchello.UkFest.Web.Ditto.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.Web.Models.VirtualContent;

    using Umbraco.Core;

    /// <summary>
    /// Stores keys for the recently viewed collection.
    /// </summary>
    public class RecentlyViewedValueResolverContext : CustomerContextValueResolverContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecentlyViewedValueResolverContext"/> class.
        /// </summary>
        public RecentlyViewedValueResolverContext()
        {
            this.Initialize();
        }

        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        public IEnumerable<Guid> Keys { get; set; }

        /// <summary>
        /// Serializes the keys to a CSV list for cookie storage.
        /// </summary>
        internal void Store()
        {
            CustomerContext.SetValue("rviewed", string.Join(",", this.Keys));
        }

        /// <summary>
        /// Adds a recent product.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        internal void AddRecentProduct(IProductContent product)
        {
            this.AddKey(product.Key);
            this.Store();
        }

        /// <summary>
        /// Safely adds a key to the recently viewed collection list.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        private void AddKey(Guid key)
        {
            const int Count = 3;

            var keys = this.Keys.ToList();


            if (keys.Count() >= Count)
            {
                if (!keys.Contains(key))
                keys.RemoveAt(0);
            }

            if (!keys.Contains(key)) keys.Add(key);

            this.Keys = keys;
        }


        /// <summary>
        /// deserialize recently viewed.
        /// </summary>
        private void Initialize()
        {
            var value = CustomerContext.GetValue("rviewed");
            this.Keys = value.IsNullOrWhiteSpace() ? new Guid[] { } : value.Split(',').Select(x => new Guid(x));
        }
    }
}