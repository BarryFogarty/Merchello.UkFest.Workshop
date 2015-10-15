namespace Merchello.UkFest.Web.Models
{
    using Umbraco.Core.Models;

    /// <summary>
    /// Site branding information.
    /// </summary>
    public class Branding
    {
        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        public IPublishedContent Logo { get; set; }

        /// <summary>
        /// Gets or sets the logo small.
        /// </summary>
        public IPublishedContent LogoSmall { get; set; }
    }
}