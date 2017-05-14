namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.credentials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        graphicalReference = c.String(nullable: false, unicode: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        lastName = c.String(nullable: false, unicode: false),
                        firstName = c.String(unicode: false),
                        birthDate = c.DateTime(precision: 0),
                        civility = c.String(unicode: false),
                        siteId = c.Int(),
                        loggin = c.String(unicode: false),
                        password = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.sites", t => t.siteId)
                .Index(t => t.siteId);
            
            CreateTable(
                "dbo.sites",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.userrights",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, unicode: false),
                        granted = c.Boolean(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.userrights", "userId", "dbo.users");
            DropForeignKey("dbo.users", "siteId", "dbo.sites");
            DropForeignKey("dbo.credentials", "userId", "dbo.users");
            DropIndex("dbo.userrights", new[] { "userId" });
            DropIndex("dbo.users", new[] { "siteId" });
            DropIndex("dbo.credentials", new[] { "userId" });
            DropTable("dbo.userrights");
            DropTable("dbo.sites");
            DropTable("dbo.users");
            DropTable("dbo.credentials");
        }
    }
}
