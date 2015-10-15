namespace Merchello.UkFest.Web.Models.DitFlo
{
    using System.Collections.Generic;

    using Our.Umbraco.Ditto;

    /// <summary>
    /// Used in mapping process between RenderModel and site specific view models.
    /// </summary>
    internal class DitFloTransferModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DitFloTransferModel"/> class.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public DitFloTransferModel(object model)
        {
            this.Model = model;
            this.ValueResolverContexts = new List<DittoValueResolverContext>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DitFloTransferModel"/> class.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="resolverContexts">
        /// The resolver contexts.
        /// </param>
        public DitFloTransferModel(object model, IEnumerable<DittoValueResolverContext> resolverContexts)
        {
            this.Model = model;
            this.ValueResolverContexts = new List<DittoValueResolverContext>(resolverContexts);
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public object Model { get; set; }

        /// <summary>
        /// Gets or sets the value resolver contexts.
        /// </summary>
        public List<DittoValueResolverContext> ValueResolverContexts { get; set; }
    }
}
