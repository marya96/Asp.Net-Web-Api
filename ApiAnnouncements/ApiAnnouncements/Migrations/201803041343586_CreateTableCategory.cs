namespace ApiAnnouncements.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Announcements", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Announcements", new[] { "CategoryId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Announcements");
        }
    }
}
