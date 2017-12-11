namespace ApiAnnouncements.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Announcements", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Announcements", "CategoryId");
            AddForeignKey("dbo.Announcements", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Announcements", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Announcements", new[] { "CategoryId" });
            DropColumn("dbo.Announcements", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
