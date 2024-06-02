namespace OnlineShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "Nombre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
