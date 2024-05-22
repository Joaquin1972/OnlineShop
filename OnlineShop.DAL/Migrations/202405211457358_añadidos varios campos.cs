namespace OnlineShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class añadidosvarioscampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DateOrder", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "DateOrder");
        }
    }
}
