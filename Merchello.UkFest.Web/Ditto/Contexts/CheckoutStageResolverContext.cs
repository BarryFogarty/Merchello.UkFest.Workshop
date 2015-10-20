namespace Merchello.UkFest.Web.Ditto.Contexts
{
    using System.Globalization;

    using Umbraco.Core;

    /// <summary>
    /// The checkout stage resolver context.
    /// </summary>
    public class CheckoutStageResolverContext : CustomerContextValueResolverContext
    {
        /// <summary>
        /// The maximum validated stage.
        /// </summary>
        private int _stage;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutStageResolverContext"/> class.
        /// </summary>
        public CheckoutStageResolverContext()
        {
            this.Initialize();
        }

        /// <summary>
        /// Gets the stage.
        /// </summary>
        public int Stage
        {
            get
            {
                return _stage;
            }
        }

        /// <summary>
        /// The set stage.
        /// </summary>
        /// <param name="stage">
        /// The stage.
        /// </param>
        public void SetStage(int stage)
        {
            CustomerContext.SetValue("costage", stage.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public void Reset()
        {
            CustomerContext.SetValue("costage", "0");
        }

        /// <summary>
        /// deserialize recently viewed.
        /// </summary>
        private void Initialize()
        {
            var value = CustomerContext.GetValue("costage");
            _stage = value.IsNullOrWhiteSpace() ? 0 : int.Parse(value);
        }
    }
}