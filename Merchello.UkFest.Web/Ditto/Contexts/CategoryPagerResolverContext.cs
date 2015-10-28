namespace Merchello.UkFest.Web.Ditto.Contexts
{
    using System.Globalization;

    using Umbraco.Core;

    /// <summary>
    /// The category pager resolver context.
    /// </summary>
    public class CategoryPagerResolverContext : CustomerContextValueResolverContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryPagerResolverContext"/> class.
        /// </summary>
        public CategoryPagerResolverContext()
        {
            this.Initialize();
        }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        public long CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the sort by.
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// The set page size.
        /// </summary>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        public void SetPageSize(int pageSize)
        {
            CustomerContext.SetValue("catPageSize", pageSize.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Sets the sort by expression.
        /// </summary>
        /// <param name="field">
        /// The field.
        /// </param>
        public void SetSortBy(string field)
        {
            CustomerContext.SetValue("catSort", field);
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        private void Initialize()
        {
            var pageSize = CustomerContext.GetValue("catPageSize");
            ItemsPerPage = pageSize.IsNullOrWhiteSpace() ? 6 : int.Parse(pageSize);

            var sortBy = CustomerContext.GetValue("catSort");
            SortBy = sortBy.IsNullOrWhiteSpace() ? "Price" : sortBy;
        }
    }
}