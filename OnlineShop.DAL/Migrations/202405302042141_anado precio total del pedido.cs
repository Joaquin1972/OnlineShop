﻿namespace OnlineShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anadopreciototaldelpedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderTotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderTotalPrice");
        }
    }
}
