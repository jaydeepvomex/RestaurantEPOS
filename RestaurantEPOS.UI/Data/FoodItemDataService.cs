using RestaurantEPOS.Model;
using RestaurantEPOS.UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantEPOS.UI.Data
{
    public class FoodItemDataService : IFoodItemDataService
    {
        private Func<RestaurantEposDbContext> _context;

        public FoodItemDataService(Func<RestaurantEposDbContext> context)
        {
            _context = context;
        }

        public IEnumerable<FoodItem> GetAll()
        {
            using (var ctx = _context())
            {
                return ctx.FoodItems.AsNoTracking().ToList();
            }
        }
    }
}
