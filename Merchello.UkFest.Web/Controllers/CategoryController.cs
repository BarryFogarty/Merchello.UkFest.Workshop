namespace Merchello.UkFest.Web.Controllers
{
    using System.Web.Mvc;

    using Merchello.UkFest.Web.Ditto.Contexts;
    using Merchello.UkFest.Web.Models.DitFlo;

    using Umbraco.Web.Models;

    /// <summary>
    /// The category controller.
    /// </summary>
    public class CategoryController : DitFloController
    {

        /// <summary>
        /// The category.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="page">
        /// The page index.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Category(RenderModel model, long page = 1)
        {
            this.RegisterValueResolverContext(
                new CategoryPagerResolverContext
                {
                    CurrentPage = page,
                });

            return this.CurrentView(model);
        }

        /// <summary>
        /// Sets the page size.
        /// </summary>
        /// <param name="itemCount">
        /// The item count.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult SetPageSize(int itemCount)
        {
            var context = new CategoryPagerResolverContext();
            context.SetPageSize(itemCount);

            return this.RedirectToCurrentUmbracoPage();
        }

        /// <summary>
        /// Sets the sort by field.
        /// </summary>
        /// <param name="sort">
        /// The sort.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult SetSortField(string sort)
        {
            var context = new CategoryPagerResolverContext();
            context.SetSortBy(sort);

            if (Request.IsAjaxRequest())
            {
                // TODO we could populate the pager again here and 
                // return the Collection partial but we would need to pass the content id as well
                return Content("success");
            }

            return this.RedirectToCurrentUmbracoPage();
        }
    }
}