namespace FoodTrucker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionMenuItemAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "MenuItemId", "dbo.MenuItem");
            DropIndex("dbo.Transaction", new[] { "MenuItemId" });
            CreateTable(
                "dbo.TransactionMenuItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuItemId = c.Int(nullable: false),
                        TransactionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItem", t => t.MenuItemId, cascadeDelete: true)
                .ForeignKey("dbo.Transaction", t => t.TransactionId, cascadeDelete: true)
                .Index(t => t.MenuItemId)
                .Index(t => t.TransactionId);
            
            AddColumn("dbo.MenuItem", "Transaction_Id", c => c.Int());
            CreateIndex("dbo.MenuItem", "Transaction_Id");
            AddForeignKey("dbo.MenuItem", "Transaction_Id", "dbo.Transaction", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionMenuItem", "TransactionId", "dbo.Transaction");
            DropForeignKey("dbo.MenuItem", "Transaction_Id", "dbo.Transaction");
            DropForeignKey("dbo.TransactionMenuItem", "MenuItemId", "dbo.MenuItem");
            DropIndex("dbo.TransactionMenuItem", new[] { "TransactionId" });
            DropIndex("dbo.TransactionMenuItem", new[] { "MenuItemId" });
            DropIndex("dbo.MenuItem", new[] { "Transaction_Id" });
            DropColumn("dbo.MenuItem", "Transaction_Id");
            DropTable("dbo.TransactionMenuItem");
            CreateIndex("dbo.Transaction", "MenuItemId");
            AddForeignKey("dbo.Transaction", "MenuItemId", "dbo.MenuItem", "Id", cascadeDelete: true);
        }
    }
}
