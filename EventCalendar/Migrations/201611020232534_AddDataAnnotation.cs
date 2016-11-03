namespace EventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "StartTime", c => c.String(nullable: false));
            AddColumn("dbo.Events", "EndTime", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "allDay", c => c.Boolean());
            DropColumn("dbo.Events", "Start");
            DropColumn("dbo.Events", "End");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "End", c => c.String());
            AddColumn("dbo.Events", "Start", c => c.String());
            AlterColumn("dbo.Events", "allDay", c => c.Boolean(nullable: false));
            DropColumn("dbo.Events", "EndTime");
            DropColumn("dbo.Events", "StartTime");
        }
    }
}
