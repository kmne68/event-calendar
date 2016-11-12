namespace EventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventType", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "StreetNumber", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Events", "StreetName", c => c.String(maxLength: 50));
            AddColumn("dbo.Events", "City", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Events", "State", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Events", "ZipCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "ZipCode");
            DropColumn("dbo.Events", "State");
            DropColumn("dbo.Events", "City");
            DropColumn("dbo.Events", "StreetName");
            DropColumn("dbo.Events", "StreetNumber");
            DropColumn("dbo.Events", "EventType");
        }
    }
}
