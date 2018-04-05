namespace Ecommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesLocalizeProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.localize_products",
                c => new
                    {
                        ProductID = c.Int(name: "Product ID", nullable: false),
                        languageID = c.Int(name: "language ID", nullable: false),
                        name = c.String(nullable: false, maxLength: 255),
                        descr = c.String(),
                        color = c.String(),
                        material = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductID, t.languageID })
                .ForeignKey("dbo.Languages", t => t.languageID, cascadeDelete: true)
                .ForeignKey("dbo.products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.languageID);
            
            AddColumn("dbo.Languages", "local name", c => c.String());
            DropColumn("dbo.product_categories", "name");
            DropColumn("dbo.product_categories", "descr");
            DropColumn("dbo.products", "name");
            DropColumn("dbo.products", "descr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.products", "descr", c => c.String());
            AddColumn("dbo.products", "name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.product_categories", "descr", c => c.String());
            AddColumn("dbo.product_categories", "name", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.localize_products", "Product ID", "dbo.products");
            DropForeignKey("dbo.localize_products", "language ID", "dbo.Languages");
            DropIndex("dbo.localize_products", new[] { "language ID" });
            DropIndex("dbo.localize_products", new[] { "Product ID" });
            DropColumn("dbo.Languages", "local name");
            DropTable("dbo.localize_products");
        }
    }
}
