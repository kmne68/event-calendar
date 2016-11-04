namespace EventCalendar.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var events = new List<Events>
            {
                new Events { EventTitle = "Keith's Bday",
                    Date = DateTime.ParseExact("11/10/2016", "0:dd/MM/yyyy", null),
                    StartTime = DateTime.ParseExact("1:30:00", "0:HH:mm", null),
                    EndTime = DateTime.ParseExact("2:30:00", "0:HH:mm", null) },
                new Events { EventTitle = "Joe's Graduation",
                    Date = DateTime.ParseExact("11/12/2016", "0:dd/MM/yyyy", null),
                    StartTime = DateTime.ParseExact("2:30:00", "0:HH:mm", null),
                    EndTime = DateTime.ParseExact("3:30:00", "0:HH:mm", null)
                }
            };

            // Assumes k.EventTitles are unique | TODO Replace this before production
            events.ForEach(e => context.Events.AddOrUpdate(k => k.EventTitle, e));
            context.SaveChanges();
        }
    }
}
