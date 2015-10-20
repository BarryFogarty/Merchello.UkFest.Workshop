namespace Merchello.UkFest.Web.Models.Checkout
{
    /// <summary>
    /// A base class for checkout forms.
    /// </summary>
    public abstract class CheckoutStageBase
    {
        /// <summary>
        /// Gets or sets the checkout step.
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        /// Gets or sets the previous URL.
        /// </summary>
        public string PreviousUrl { get; set; }
    }
}