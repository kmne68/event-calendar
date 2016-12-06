namespace EventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumForAllDayEvent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "IsAllDay", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Event", "IsAllDay", c => c.Boolean());
        }
    }
}
