namespace OnlineShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anadoshoppinCarts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShoppingCarts", "Product_Id", "dbo.Products");
            DropIndex("dbo.ShoppingCarts", new[] { "Product_Id" });
            DropIndex("dbo.ShoppingCarts", new[] { "User_Id" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}
