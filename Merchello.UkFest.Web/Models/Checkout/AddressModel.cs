namespace Merchello.UkFest.Web.Models.Checkout
{
    using System.ComponentModel.DataAnnotations;

    using Merchello.Core;

    /// <summary>
    /// A model for addresses.
    /// </summary>
    public class AddressModel : CheckoutStageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressModel"/> class.
        /// </summary>
        public AddressModel()
        {
            this.CountryCode = "GB";
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the address type.
        /// </summary>
        public AddressType AddressType { get; set; }

        /// <summary>
        /// Gets or sets the address 1.
        /// </summary>
        [Required]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the address 2.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the locality, city or town
        /// </summary>
        [Required]
        public string Locality { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        [Required]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        [Required]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [EmailAddress, Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }
    }
}