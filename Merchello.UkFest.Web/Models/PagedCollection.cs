namespace Merchello.UkFest.Web.Models
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a paged collection.
    /// </summary>
    public class PagedCollection
    {
        /// <summary>
        /// Gets or sets the total items.
        /// </summary>
        public long TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        public long CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public long PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        public long TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the sort field.
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// Gets a value indicating whether is first page.
        /// </summary>
        public bool IsFirstPage
        {
            get
            {
                return this.CurrentPage <= 1;
            }
        }

        /// <summary>
        /// Gets a value indicating whether is last page.
        /// </summary>
        public bool IsLastPage
        {
            get
            {
                return this.CurrentPage >= this.TotalPages;
            }
        }
    }

    /// <summary>
    /// The paged collection.
    /// </summary>
    /// <typeparam name="TResultType">
    /// The type of paged item
    /// </typeparam>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public class PagedCollection<TResultType> : PagedCollection
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public IEnumerable<TResultType> Items { get; set; }
    }
}