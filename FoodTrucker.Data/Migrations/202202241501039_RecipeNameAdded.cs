namespace FoodTrucker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipe", "Name");
        }
    }
}
