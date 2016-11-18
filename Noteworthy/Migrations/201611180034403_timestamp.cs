namespace Noteworthy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Timestamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Timestamp");
        }
    }
}
