using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantEPOS.Model;

namespace RestaurantEPOS.UI.Interface
{
    public interface IFoodItemDataService
    {
        IEnumerable<FoodItem> GetAll();
    }
}