using RestaurantEPOS.Model;
using System.Collections.Generic;

namespace RestaurantEPOS.UI.Interface
{
    public interface ICategoryDataService
    {
        IEnumerable<Category> GetAll();
        Category GetCategoryById(int categoryId);
        void InsertCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category category);
    }
}
