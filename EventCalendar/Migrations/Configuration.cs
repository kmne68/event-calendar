namespace EventCalendar.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventCalendar.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EventCalendar.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Events.AddOrUpdate(
                    new Events {
                        EventTitle = "Event 1",
                        Date = DateTime.ParseExact("10/10/2016", "0:dd/MM/yyyy", null),
                        StartTime = DateTime.ParseExact("1:30:00", "0:HH:mm", null),
                        EndTime = DateTime.ParseExact("2:30:00", "0:HH:mm", null) },

                     new Events {
                        EventTitle = "Event 2",
                        Date = DateTime.ParseExact("10/12/2016", "0:dd/MM/yyyy", null),
                        StartTime = DateTime.ParseExact("2:30:00", "0:HH:mm", null),
                        EndTime = DateTime.ParseExact("3:30:00", "0:HH:mm", null)
                     }
                );
        }
    }
}
