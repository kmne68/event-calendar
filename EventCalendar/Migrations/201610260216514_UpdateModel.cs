namespace EventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "Date", c => c.String());
            AlterColumn("dbo.Events", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Events", "id");
        }
    }
}
