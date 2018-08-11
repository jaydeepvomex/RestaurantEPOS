using RestaurantEPOS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEPOS.DataAccess.Interface
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> Get();
    }
}
