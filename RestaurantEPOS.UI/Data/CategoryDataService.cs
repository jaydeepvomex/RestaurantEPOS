using RestaurantEPOS.UI.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RestaurantEPOS.Model.Lookup;
using System.Threading.Tasks;
using System;

namespace RestaurantEPOS.UI.Data
{
    public class CategoryDataService : ICategoryDataService
    {
        private Func<RestaurantEposDbContext> _contextCreator;

        public CategoryDataService(Func<RestaurantEposDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetCategoryLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Categories.AsNoTracking()
                    .Select(f =>
                    new LookupItem
                    {
                        Id = f.Id,
                        DisplayMember = f.CategoryName
                    })
                    .ToListAsync();
            }
        }


        //public IEnumerable<Category> GetAll()
        //{
        //    return context.Categories.ToList();
        //}

        //public Category GetCategoryById(int categoryId)
        //{
        //    return context.Categories.Find(categoryId);
        //}

        //public void InsertCategory(Category category)
        //{
        //    context.Categories.Add(category);
        //    context.SaveChanges();
        //}

        //public void DeleteCategory(int categoryId)
        //{
        //    Category category = context.Categories.Find(categoryId);
        //    context.Categories.Remove(category);
        //    context.SaveChanges();
        //}

        //public void UpdateCategory(Category category)
        //{
        //    context.Entry(category).State = EntityState.Modified;
        //    context.SaveChanges();
        //}


    }
}
