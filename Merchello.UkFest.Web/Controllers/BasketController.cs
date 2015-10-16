namespace Merchello.UkFest.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Merchello.Core.Models;
    using Merchello.UkFest.Web.Models;
    using Merchello.UkFest.Web.Resolvers;
    using Merchello.Web;
    using Merchello.Web.Models.ContentEditing;
    using Merchello.Web.Mvc;

    using Newtonsoft.Json;

    /// <summary>
    /// A controller for handling Basket operations.
    /// </summary>
    public class BasketController : MerchelloSurfaceController
    {
        /// <summary>
        /// Adds an item to the basket.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult AddToBasket(AddToBasket model)
        {
            // Disable VAT in initial lookup so we don't double tax
            var merchello = new MerchelloHelper(false);

            // we want to include VAT
            Basket.EnableDataModifiers = true;

            var product = merchello.Query.Product.GetByKey(model.ProductKey);

            if (model.OptionChoices != null && model.OptionChoices.Any())
            {
                var extendedData = new ExtendedDataCollection();
                var variant = product.GetProductVariantDisplayWithAttributes(model.OptionChoices);
                //// serialize the attributes here as they are need in the design
                extendedData.SetValue(Constants.ExtendedDataKeys.BasketItemAttributes, JsonConvert.SerializeObject(variant.Attributes));
                Basket.AddItem(variant, variant.Name, 1, extendedData);
            }
            else
            {
                Basket.AddItem(product, product.Name, 1);
            }

            Basket.Save();

            if (Request.IsAjaxRequest())
            {
                // this would be the partial for the pop window
                return Content("Form submitted");
            }

            return RedirectToUmbracoPage(ContentResolver.Instance.GetBasketContent());
        }

        /// <summary>
        /// Updates basket quantities.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult UpdateBasket(UpdateBasket model)
        {
            return this.RedirectToCurrentUmbracoPage();
        }
    }
}