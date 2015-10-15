namespace Merchello.UkFest.Web.Mvc
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Merchello.UkFest.Web.Models;
    using Merchello.UkFest.Web.Models.DitFlo;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// The DitFlo view.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// The type of view model
    /// </typeparam>
    public abstract class DitFloView<TViewModel> : UmbracoViewPage<DitFloViewModel<TViewModel>>
            where TViewModel : class
    {
        /// <summary>
        /// Sets the view data.
        /// </summary>
        /// <param name="viewData">
        /// The view data.
        /// </param>
        protected override void SetViewData(ViewDataDictionary viewData)
        {
            // If model is already ditflo view model, use it
            if (viewData.Model is DitFloViewModel<TViewModel>)
            {
                base.SetViewData(viewData);
                return;
            }

            // Gather dit flow view model properties
            var model = viewData.Model;
            var resolverContexts = new List<DittoValueResolverContext>();

            var transferModel = model as DitFloTransferModel;
            if (transferModel != null)
            {
                model = transferModel.Model;
                resolverContexts = transferModel.ValueResolverContexts;
            }

            // We need to give each view it's own view data dictonary
            // to allow them to have different model types
            var newViewData = new ViewDataDictionary(viewData);

            // Get current content / culture
            var content = this.UmbracoContext.PublishedContentRequest.PublishedContent;
            var culture = this.UmbracoContext.PublishedContentRequest.Culture;

            // Process model
            var publishedContent = model as IPublishedContent;
            if (publishedContent != null)
            {
                content = publishedContent;
            }

            var renderModel = model as RenderModel;
            if (renderModel != null)
            {
                content = renderModel.Content;
                culture = renderModel.CurrentCulture;
            }

            var typedModel = model as TViewModel;

            // Create view model
            newViewData.Model = new DitFloViewModel<TViewModel>(content, culture, resolverContexts, typedModel);

            base.SetViewData(newViewData);
        }
    }
}
