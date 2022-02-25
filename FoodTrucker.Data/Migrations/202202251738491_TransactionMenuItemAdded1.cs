namespace FoodTrucker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionMenuItemAdded1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItem", "Transaction_Id", "dbo.Transaction");
            DropIndex("dbo.MenuItem", new[] { "Transaction_Id" });
            AddColumn("dbo.MenuItem", "Name", c => c.String());
            AddColumn("dbo.Transaction", "TransactionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaction", "TransactionMenuItemId", c => c.Int(nullable: false));
            DropColumn("dbo.MenuItem", "Transaction_Id");
            DropColumn("dbo.Transaction", "MenuItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "MenuItemId", c => c.Int(nullable: false));
            AddColumn("dbo.MenuItem", "Transaction_Id", c => c.Int());
            DropColumn("dbo.Transaction", "TransactionMenuItemId");
            DropColumn("dbo.Transaction", "TransactionDate");
            DropColumn("dbo.MenuItem", "Name");
            CreateIndex("dbo.MenuItem", "Transaction_Id");
            AddForeignKey("dbo.MenuItem", "Transaction_Id", "dbo.Transaction", "Id");
        }
    }
}
