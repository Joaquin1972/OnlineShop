namespace OnlineShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageañadido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.OrderDetails", "ProductName", c => c.String());
            AddColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.OrderDetails", "ProductId");
            DropColumn("dbo.OrderDetails", "TotalPrice");
            DropColumn("dbo.Orders", "TotalOrderPrice");
            DropColumn("dbo.Products", "FotographyPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "FotographyPath", c => c.String());
            AddColumn("dbo.Orders", "TotalOrderPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Products");
            DropIndex("dbo.Images", new[] { "Product_Id" });
            DropColumn("dbo.OrderDetails", "UnitPrice");
            DropColumn("dbo.OrderDetails", "ProductName");
            DropTable("dbo.Images");
            CreateIndex("dbo.OrderDetails", "ProductId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
