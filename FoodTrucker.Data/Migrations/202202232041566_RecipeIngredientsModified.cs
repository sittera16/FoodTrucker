namespace FoodTrucker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeIngredientsModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "MenuItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItem", "RecipeId");
            CreateIndex("dbo.RecipeIngredient", "IngredientId");
            CreateIndex("dbo.RecipeIngredient", "RecipeId");
            CreateIndex("dbo.Schedule", "LocationId");
            CreateIndex("dbo.Transaction", "CustomerId");
            CreateIndex("dbo.Transaction", "MenuItemId");
            CreateIndex("dbo.Transaction", "LocationId");
            CreateIndex("dbo.Transaction", "EmployeeId");
            AddForeignKey("dbo.RecipeIngredient", "IngredientId", "dbo.Ingredient", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeIngredient", "RecipeId", "dbo.Recipe", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuItem", "RecipeId", "dbo.Recipe", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Schedule", "LocationId", "dbo.Location", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "EmployeeId", "dbo.Employee", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "LocationId", "dbo.Location", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "MenuItemId", "dbo.MenuItem", "Id", cascadeDelete: true);
            DropColumn("dbo.Recipe", "RecipeIngredientId");
            DropColumn("dbo.Transaction", "MenuId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "MenuId", c => c.Int(nullable: false));
            AddColumn("dbo.Recipe", "RecipeIngredientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transaction", "MenuItemId", "dbo.MenuItem");
            DropForeignKey("dbo.Transaction", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Transaction", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Schedule", "LocationId", "dbo.Location");
            DropForeignKey("dbo.MenuItem", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.RecipeIngredient", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.RecipeIngredient", "IngredientId", "dbo.Ingredient");
            DropIndex("dbo.Transaction", new[] { "EmployeeId" });
            DropIndex("dbo.Transaction", new[] { "LocationId" });
            DropIndex("dbo.Transaction", new[] { "MenuItemId" });
            DropIndex("dbo.Transaction", new[] { "CustomerId" });
            DropIndex("dbo.Schedule", new[] { "LocationId" });
            DropIndex("dbo.RecipeIngredient", new[] { "RecipeId" });
            DropIndex("dbo.RecipeIngredient", new[] { "IngredientId" });
            DropIndex("dbo.MenuItem", new[] { "RecipeId" });
            DropColumn("dbo.Transaction", "MenuItemId");
        }
    }
}
