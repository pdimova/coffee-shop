namespace CoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartParopertiesIsDeletedandIsCheckedOut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Carts", "IsCheckedOut", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "IsCheckedOut");
            DropColumn("dbo.Carts", "IsDeleted");
        }
    }
}