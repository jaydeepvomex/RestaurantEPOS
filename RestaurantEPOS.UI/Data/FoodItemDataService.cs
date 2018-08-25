using RestaurantEPOS.Model;
using RestaurantEPOS.UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantEPOS.Model.Lookup;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RestaurantEPOS.UI.Data
{
    public class FoodItemDataService : IFoodItemDataService
    {
        private Func<RestaurantEposDbContext> _contextCreator;

        public FoodItemDataService(Func<RestaurantEposDbContext> context)
        {
            _contextCreator = context;
        }

        public async Task<IEnumerable<LookupItem>> GetFoodItemAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.FoodItems.AsNoTracking()
                    .Select(f =>
                    new LookupItem
                    {
                        Id = f.Id,
                        DisplayMember = f.Name
                    })
                    .ToListAsync();
            }
        }
    }
}
