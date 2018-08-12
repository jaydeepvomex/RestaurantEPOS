using RestaurantEPOS.UI.Interface;
using System;
using RestaurantEPOS.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RestaurantEPOS.UI
{
    public class StaffDataService : IStaffDataService
    {
        private Func<RestaurantEposDbContext> _context;

        public StaffDataService(Func<RestaurantEposDbContext> context)
        {
            _context = context;
        }

        public async Task<List<Staff>> GetAllAsync()
        {
            using (var ctx = _context())
            {
                return await ctx.Staffs.AsNoTracking().ToListAsync();
            }
        }
    }
}
