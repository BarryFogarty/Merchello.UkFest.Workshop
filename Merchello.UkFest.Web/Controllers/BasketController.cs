namespace Merchello.UkFest.Web.Controllers
{
    using System;
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
            // Tax calc is a DataModifier chain process and if its set to true here it will perform the calculation twice
            var merchello = new MerchelloHelper(false);

            // we want to include VAT
            Basket.EnableDataModifiers = true;

            var product = merchello.Query.Product.GetByKey(model.ProductKey);

            if (model.OptionChoice != Guid.Empty)
            {
                var extendedData = new ExtendedDataCollection();
                var variant = product.GetProductVariantDisplayWithAttributes(new[] { model.OptionChoice });
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
            // The only thing that can be updated in this basket is the quantity
            foreach (var item in model.Items.Where(item => this.Basket.Items.First(x => x.Key == item.Key).Quantity != item.Quantity))
            {
                this.Basket.UpdateQuantity(item.Key, item.Quantity);
            }

            this.Basket.Save();

            return this.RedirectToCurrentUmbracoPage();
        }

        /// <summary>
        /// Removes an item from the basket.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult Remove(Guid key)
        {
            EnsureOwner(Basket.Items, key);
            
            //// remove the item by its pk.  
            Basket.RemoveItem(key);

            Basket.Save();

            return this.RedirectToCurrentUmbracoPage();
        } 
    }
}