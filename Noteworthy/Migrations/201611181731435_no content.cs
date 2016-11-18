namespace Noteworthy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nocontent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notes", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Content", c => c.String(nullable: false));
        }
    }
}
