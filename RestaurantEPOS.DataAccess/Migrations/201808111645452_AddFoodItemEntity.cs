namespace RestaurantEPOS.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoodItemEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodItem", "CategoryId", "dbo.Category");
            DropIndex("dbo.FoodItem", new[] { "CategoryId" });
            DropTable("dbo.FoodItem");
        }
    }
}
