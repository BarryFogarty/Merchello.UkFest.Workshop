namespace Merchello.UkFest.Web.Controllers
{
    using System.Web.Mvc;

    using Merchello.UkFest.Web.Models.Category;

    using Our.Umbraco.Ditto;

    using Umbraco.Web.Models;

    public class CategoryController : DitFloController
    {

        public ActionResult CategoryTop(RenderModel model)
        {
            var transferModel = model.As<CategoryTop>();
            return this.CurrentView(transferModel);
        }


        public ActionResult Category(RenderModel model)
        {
            var transferModel = model.As<Category>();
            return this.CurrentView(transferModel);
        }
    }
}