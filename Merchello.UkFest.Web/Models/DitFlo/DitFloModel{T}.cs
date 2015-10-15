namespace Merchello.UkFest.Web.Models.DitFlo
{
    using System.Collections.Generic;
    using System.Globalization;

    using Our.Umbraco.Ditto;

    using Umbraco.Core.Models;

    /// <summary>
    /// Represents a DitFlo view model.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// The type of view model
    /// </typeparam>
    public class DitFloViewModel<TViewModel> : BaseDitFloViewModel
        where TViewModel : class
    {
        /// <summary>
        /// The view model object.
        /// </summary>
        private TViewModel _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="DitFloViewModel{TViewModel}"/> class.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <param name="valueResolverContexts">
        /// The value resolver contexts.
        /// </param>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        public DitFloViewModel(
            IPublishedContent content,
            CultureInfo culture = null,
            IEnumerable<DittoValueResolverContext> valueResolverContexts = null,
            TViewModel viewModel = null)
            : base(content, culture, valueResolverContexts)
        {
            if (viewModel != null)
                this.View = viewModel;
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        public TViewModel View
        {
            get
            {
                if (this._view == null)
                {
                    if (this.Content is TViewModel)
                    {
                        this._view = this.Content as TViewModel;
                    }
                    else
                    {
                        this._view = this.Content.As<TViewModel>(valueResolverContexts: this.ValueResolverContexts);
                    }
                }

                return this._view;
            }

            internal set
            {
                this._view = value;
            }
        }

    }
}
