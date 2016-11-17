namespace Noteworthy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        Title = c.String(maxLength: 60),
                        Content = c.String(nullable: false),
                        AudioS3Path = c.String(),
                        AudioAsText = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 70),
                        DisplayName = c.String(maxLength: 70),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.DisplayName, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notes", "TopicId", "dbo.Topics");
            DropIndex("dbo.Users", new[] { "DisplayName" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Notes", new[] { "TopicId" });
            DropIndex("dbo.Notes", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Topics");
            DropTable("dbo.Notes");
        }
    }
}
