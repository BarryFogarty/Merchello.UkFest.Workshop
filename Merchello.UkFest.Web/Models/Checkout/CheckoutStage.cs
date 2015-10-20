namespace Merchello.UkFest.Web.Models.Checkout
{
    /// <summary>
    /// The checkout stage.
    /// </summary>
    public enum CheckoutStage
    {
        /// <summary>
        /// Billing address form.
        /// </summary>
        BillingAddress,

        /// <summary>
        /// Shipping address form.
        /// </summary>
        ShippingAddress,

        /// <summary>
        /// Delivery method selection.
        /// </summary>
        DeliveryMethod,

        /// <summary>
        /// Confirm the order.
        /// </summary>
        Confirm
    }
}