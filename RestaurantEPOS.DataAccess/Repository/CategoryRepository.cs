using RestaurantEPOS.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantEPOS.Model;
using System.Data.Entity;

namespace RestaurantEPOS.DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private RestaurantEposDbContext context;

        public CategoryRepository(RestaurantEposDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetItems()
        {
            return context.Categories.ToList();
        }

        public Category GetCategoryByID(int categoryId)
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
