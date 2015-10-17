namespace Merchello.UkFest.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Merchello.UkFest.Web.Models;
    using Merchello.Web;
    using Merchello.Web.Mvc;

    using Our.Umbraco.Ditto;

    using Umbraco.Web.Mvc;

    /// <summary>
    /// The modal controller.
    /// </summary>
    public class ModalController : SurfaceController
    {
        /// <summary>
        /// The Merchello Helper.
        /// </summary>
        private readonly MerchelloHelper _merchello = new MerchelloHelper();

        /// <summary>
        /// Gets the modal.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult Modal(Guid key)
        {
            var product = _merchello.TypedProductContent(key);
            
            return this.PartialView(product.As<ProductDetail>());
        }
    }
}