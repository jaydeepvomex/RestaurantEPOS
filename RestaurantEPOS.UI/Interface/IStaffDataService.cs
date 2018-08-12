using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantEPOS.UI.Interface
{
    public interface IStaffDataService
    {
        Task<List<Model.Entities.Staff>> GetAllAsync();
    }
}