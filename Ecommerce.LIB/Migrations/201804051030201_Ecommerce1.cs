namespace Ecommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ecommerce1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product_categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        descr = c.String(),
                        parent_id = c.Int(),
                        Created_At = c.DateTime(nullable: false),
                        Modified_At = c.DateTime(nullable: false),
                        Deleted_At = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.product_categories", t => t.parent_id)
                .Index(t => t.parent_id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        product_code = c.String(nullable: false, maxLength: 50),
                        ean_barcode = c.String(maxLength: 25),
                        name = c.String(nullable: false, maxLength: 255),
                        descr = c.String(),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        price_type_id = c.Int(),
                        is_active = c.Boolean(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                        Modified_At = c.DateTime(nullable: false),
                        Deleted_At = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProductProductCategories",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        ProductCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.ProductCategory_Id })
                .ForeignKey("dbo.products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.product_categories", t => t.ProductCategory_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.ProductCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductProductCategories", "ProductCategory_Id", "dbo.product_categories");
            DropForeignKey("dbo.ProductProductCategories", "Product_Id", "dbo.products");
            DropForeignKey("dbo.product_categories", "parent_id", "dbo.product_categories");
            DropIndex("dbo.ProductProductCategories", new[] { "ProductCategory_Id" });
            DropIndex("dbo.ProductProductCategories", new[] { "Product_Id" });
            DropIndex("dbo.product_categories", new[] { "parent_id" });
            DropTable("dbo.ProductProductCategories");
            DropTable("dbo.products");
            DropTable("dbo.product_categories");
        }
    }
}
