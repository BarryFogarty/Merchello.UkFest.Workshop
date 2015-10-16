namespace Merchello.UkFest.Web.Models.Category
{
    using System.Collections.Generic;

    public class Category
    {
        public string Title { get; set; }
        
        public IEnumerable<ProductListing> SubCategories { get; set; } 
    }
}