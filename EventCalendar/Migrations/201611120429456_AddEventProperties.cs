namespace EventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "EventType", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "StreetNumber", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Event", "StreetName", c => c.String(maxLength: 50));
            AddColumn("dbo.Event", "City", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Event", "State", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Event", "ZipCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "ZipCode");
            DropColumn("dbo.Event", "State");
            DropColumn("dbo.Event", "City");
            DropColumn("dbo.Event", "StreetName");
            DropColumn("dbo.Event", "StreetNumber");
            DropColumn("dbo.Event", "EventType");
        }
    }
}
