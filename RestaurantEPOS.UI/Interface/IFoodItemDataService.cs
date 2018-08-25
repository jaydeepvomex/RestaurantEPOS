using System.Collections.Generic;
using RestaurantEPOS.Model.Lookup;
using System.Threading.Tasks;


namespace RestaurantEPOS.UI.Interface
{
    public interface IFoodItemDataService
    {
        Task<IEnumerable<LookupItem>> GetFoodItemAsync();
    }
}