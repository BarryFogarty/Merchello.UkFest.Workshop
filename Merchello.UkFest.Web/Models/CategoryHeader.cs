namespace Merchello.UkFest.Web.Models
{
    using Our.Umbraco.Ditto;

    /// <summary>
    /// The category header.
    /// </summary>
    public class CategoryHeader
    {
        /// <summary>
        /// Gets or sets the brief.
        /// </summary>
        [UmbracoProperty("brief")]
        public string Brief { get; set; } 
    }
}