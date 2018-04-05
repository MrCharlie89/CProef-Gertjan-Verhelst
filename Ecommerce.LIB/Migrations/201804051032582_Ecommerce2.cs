namespace Ecommerce.LIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ecommerce2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.supplier",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        vatnumber = c.String(nullable: false, maxLength: 20),
                        suppliername = c.String(nullable: false, maxLength: 255),
                        adress = c.String(nullable: false, maxLength: 255),
                        phonenumber = c.String(nullable: false, maxLength: 15),
                        emailadress = c.String(nullable: false),
                        Created_At = c.DateTime(nullable: false),
                        Modified_At = c.DateTime(nullable: false),
                        Deleted_At = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        user_id = c.Guid(nullable: false),
                        first_name = c.String(nullable: false, maxLength: 255),
                        last_name = c.String(nullable: false, maxLength: 255),
                        user_name = c.String(nullable: false, maxLength: 50),
                        encrypted_pwd = c.String(nullable: false, maxLength: 255),
                        pwd_salt = c.String(maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        Created_At = c.DateTime(nullable: false),
                        Modified_At = c.DateTime(nullable: false),
                        Deleted_At = c.DateTime(),
                    })
                .PrimaryKey(t => t.user_id)
                .Index(t => t.user_name, unique: true)
                .Index(t => t.email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.users", new[] { "email" });
            DropIndex("dbo.users", new[] { "user_name" });
            DropTable("dbo.users");
            DropTable("dbo.supplier");
        }
    }
}
