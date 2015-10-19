namespace Merchello.UkFest.Web.Controllers
{
    using System;
    using System.Web.Http;

    using Merchello.UkFest.Web.Models.Api;
    using Merchello.Web;
    using Merchello.Web.Models.ContentEditing;

    using Umbraco.Web.WebApi;

    /// <summary>
    /// The modal controller.
    /// </summary>
    [JsonCamelCaseFormatter]
    public class ModalApiController : UmbracoApiController
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
        /// The <see cref="ProductDisplay"/>.
        /// </returns>
        [HttpGet]
        public ModalProduct Modal(Guid key)
        {
            var product = _merchello.TypedProductContent(key);

            return product.AsModalProduct();
        }
    }
}