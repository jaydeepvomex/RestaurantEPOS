using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEPOS.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<FoodItem> FoodItems { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
