namespace RestaurantEPOS.UI.Migrations
{
    using RestaurantEPOS.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantEPOS.UI.RestaurantEposDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestaurantEPOS.UI.RestaurantEposDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. 
            context.Categories.AddOrUpdate(
                f => f.CategoryName,
                new Category { CategoryName = "Veg Starters" },
                new Category { CategoryName = "Non-Veg Starters" },
                new Category { CategoryName = "Indo-Chinese Veg" },
                new Category { CategoryName = "Indo-Chinese Non-Veg" },
                new Category { CategoryName = "Chef's Specialities" },
                new Category { CategoryName = "Vegetarian Dishes" },
                new Category { CategoryName = "Non-Veg Curry Dishes" },
                new Category { CategoryName = "Methi & Saag Dishes" },
                new Category { CategoryName = "Naan Breads" },
                new Category { CategoryName = "Rice" } 
                );
        }
    }
}
