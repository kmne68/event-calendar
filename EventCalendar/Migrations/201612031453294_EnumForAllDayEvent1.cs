namespace EventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumForAllDayEvent1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "EventTitle", c => c.String());
            AlterColumn("dbo.Event", "StreetNumber", c => c.String());
            AlterColumn("dbo.Event", "StreetName", c => c.String());
            AlterColumn("dbo.Event", "City", c => c.String());
            AlterColumn("dbo.Event", "State", c => c.String());
            AlterColumn("dbo.Event", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Event", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Event", "State", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Event", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Event", "StreetName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Event", "StreetNumber", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Event", "EventTitle", c => c.String(nullable: false));
        }
    }
}
