namespace Noteworthy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "IsRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "IsRead");
        }
    }
}
