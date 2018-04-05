namespace Ecommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ecommerce6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Languages", "languagename", c => c.String(nullable: false));
            AddColumn("dbo.Languages", "iso", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Languages", "iso");
            DropColumn("dbo.Languages", "languagename");
        }
    }
}
