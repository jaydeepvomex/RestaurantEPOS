using RestaurantEPOS.Model;
using RestaurantEPOS.Model.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RestaurantEPOS.DataAccess
{
    public class RestaurantEposDbContext: DbContext
    {
        public RestaurantEposDbContext() : base("RestaurantEposDb")
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
