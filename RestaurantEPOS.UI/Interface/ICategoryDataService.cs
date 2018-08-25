using RestaurantEPOS.Model.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantEPOS.UI.Interface
{
    public interface ICategoryDataService
    {
        //IEnumerable<Category> GetAll();
        //Category GetCategoryById(int categoryId);
        //void InsertCategory(Category category);
        //void DeleteCategory(int categoryId);
        //void UpdateCategory(Category category);
        Task<IEnumerable<LookupItem>> GetCategoryLookupAsync();
    }
}
