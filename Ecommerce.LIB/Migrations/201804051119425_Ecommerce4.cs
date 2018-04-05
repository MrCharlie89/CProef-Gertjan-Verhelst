namespace Ecommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ecommerce4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localize_ProductCategory",
                c => new
                    {
                        categoryID = c.Int(name: "category ID", nullable: false),
                        languageID = c.Int(name: "language ID", nullable: false),
                        name = c.String(nullable: false, maxLength: 255),
                        descr = c.String(),
                    })
                .PrimaryKey(t => new { t.categoryID, t.languageID })
                .ForeignKey("dbo.product_categories", t => t.categoryID, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.languageID, cascadeDelete: true)
                .Index(t => t.categoryID)
                .Index(t => t.languageID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created_At = c.DateTime(nullable: false),
                        Modified_At = c.DateTime(nullable: false),
                        Deleted_At = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Localize_ProductCategory", "language ID", "dbo.Languages");
            DropForeignKey("dbo.Localize_ProductCategory", "category ID", "dbo.product_categories");
            DropIndex("dbo.Localize_ProductCategory", new[] { "language ID" });
            DropIndex("dbo.Localize_ProductCategory", new[] { "category ID" });
            DropTable("dbo.Languages");
            DropTable("dbo.Localize_ProductCategory");
        }
    }
}
