namespace Ecommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ecommerce5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductProductCategories", "Product_Id", "dbo.products");
            DropForeignKey("dbo.ProductProductCategories", "ProductCategory_Id", "dbo.product_categories");
            DropIndex("dbo.ProductProductCategories", new[] { "Product_Id" });
            DropIndex("dbo.ProductProductCategories", new[] { "ProductCategory_Id" });
            AddColumn("dbo.products", "ProductCategory_Id", c => c.Int());
            CreateIndex("dbo.products", "ProductCategory_Id");
            AddForeignKey("dbo.products", "ProductCategory_Id", "dbo.product_categories", "id");
            DropTable("dbo.ProductProductCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductProductCategories",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        ProductCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.ProductCategory_Id });
            
            DropForeignKey("dbo.products", "ProductCategory_Id", "dbo.product_categories");
            DropIndex("dbo.products", new[] { "ProductCategory_Id" });
            DropColumn("dbo.products", "ProductCategory_Id");
            CreateIndex("dbo.ProductProductCategories", "ProductCategory_Id");
            CreateIndex("dbo.ProductProductCategories", "Product_Id");
            AddForeignKey("dbo.ProductProductCategories", "ProductCategory_Id", "dbo.product_categories", "id", cascadeDelete: true);
            AddForeignKey("dbo.ProductProductCategories", "Product_Id", "dbo.products", "id", cascadeDelete: true);
        }
    }
}
