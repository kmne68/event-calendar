namespace EventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        title = c.String(),
                        date = c.String(),
                        start = c.String(),
                        end = c.String(),
                        url = c.String(),
                        allDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            DropTable("dbo.Events");
        }
    }
}
