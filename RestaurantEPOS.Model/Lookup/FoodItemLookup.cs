using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEPOS.Model.Lookup
{
    public class FoodItemLookup : LookupItem
    {
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
