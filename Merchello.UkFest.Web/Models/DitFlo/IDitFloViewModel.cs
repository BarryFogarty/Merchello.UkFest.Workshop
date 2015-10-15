namespace Merchello.UkFest.Web.Models.DitFlo
{
    using Umbraco.Core.Models;
    using Umbraco.Web.Models;

    /// <summary>
    /// Defines a DitFloViewModel.
    /// </summary>
    public interface IDitFloViewModel : IRenderModel
    {
        /// <summary>
        /// Gets the current page.
        /// </summary>
        IPublishedContent CurrentPage { get; }
    }
}