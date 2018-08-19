using RestaurantEPOS.UI.Interface;
using System.Collections.Generic;
using System.Linq;
using RestaurantEPOS.Model;
using System.Data.Entity;

namespace RestaurantEPOS.UI.Repository
{
    public class CategoryDataService : ICategoryDataService
    {
        private RestaurantEposDbContext context;

        public CategoryDataService(RestaurantEposDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return context.Categories.Find(categoryId);
        }

        public void InsertCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = context.Categories.Find(categoryId);
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
