namespace Merchello.UkFest.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Merchello.UkFest.Web.Models.DitFlo;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Logging;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// The base DitFloController.
    /// </summary>
    /// <remarks>
    /// No changes
    /// </remarks>
    public abstract class DitFloController : SurfaceController, IRenderMvcController
    {
        /// <summary>
        /// A list of resolver contexts.
        /// </summary>
        protected List<DittoValueResolverContext> _resolverContexts;

        /// <summary>
        /// Initializes a new instance of the <see cref="DitFloController"/> class.
        /// </summary>
        protected DitFloController()
        {
            this._resolverContexts = new List<DittoValueResolverContext>();
        }

        public virtual ActionResult Index(RenderModel model)
        {
            return this.CurrentView(model);
        }

        protected virtual ActionResult CurrentView(object model = null)
        {
            if (model == null)
                model = this.CurrentPage;

            var transferModel = new DitFloTransferModel(model, this._resolverContexts);

            var viewName = this.ControllerContext.RouteData.Values["action"].ToString();

            if (this.ViewExists(viewName, false))
                return this.View(viewName, transferModel);

            var empty = string.Empty;
            return this.Content(empty);
        }

        protected virtual ActionResult CurrentPartialView(object model = null)
        {
            if (model == null)
                model = this.CurrentPage;

            var transferModel = new DitFloTransferModel(model, this._resolverContexts);

            var viewName = this.ControllerContext.RouteData.Values["action"].ToString();

            if (this.ViewExists(viewName, true))
                return this.PartialView(viewName, transferModel);

            var empty = string.Empty;
            return this.Content(empty);
        }

        protected bool ViewExists(string viewName, bool isPartial = false)
        {
            var result = !isPartial
                ? ViewEngines.Engines.FindView(this.ControllerContext, viewName, null)
                : ViewEngines.Engines.FindPartialView(this.ControllerContext, viewName);

            if (result.View != null)
                return true;

            LogHelper.Warn<DitFloController>("No view file found with the name " + viewName);
            return false;
        }

        protected virtual void RegisterValueResolverContext<TContextType>(TContextType context)
            where TContextType : DittoValueResolverContext
        {
            this._resolverContexts.Add(context);
        }
    }
}
