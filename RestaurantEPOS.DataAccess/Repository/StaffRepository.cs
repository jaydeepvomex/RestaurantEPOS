using RestaurantEPOS.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantEPOS.Model.Entities;

namespace RestaurantEPOS.DataAccess.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private RestaurantEposDbContext context;

        public StaffRepository(RestaurantEposDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Staff> Get()
        {
            return context.Staffs.ToList();
        }
    }
}
