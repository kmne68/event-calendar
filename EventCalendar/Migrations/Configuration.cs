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
                    EventDate = DateTime.Parse("2016-11-09"),
                    StartTime = DateTime.ParseExact("01:30:01 PM", "hh:mm:ss tt", null),
                    EndTime = DateTime.ParseExact("02:30:00 PM", "hh:mm:ss tt", null),
                    EventType = EventType.Birthday,
                    StreetNumber = "1309",
                    StreetName = "Maple St.",
                    City = "Ballwin",
                    State = "MO",
                    ZipCode = "6313" 
                },
                new Events { EventTitle = "Joe's Graduation",
                    EventDate = DateTime.Parse("2016-11-10"),
                    StartTime = DateTime.ParseExact("02:30:00 PM", "hh:mm:ss tt", null),
                    EndTime = DateTime.ParseExact("03:30:00 PM", "hh:mm:ss tt", null),
                    EventType = EventType.Graduation,
                    StreetNumber = "109",
                    StreetName = "Main St.",
                    City = "Manchester",
                    State = "MO",
                    ZipCode = "6345"
                }
            };

            // Assumes k.EventTitles are unique | TODO Replace this before production
            events.ForEach(e => context.Events.AddOrUpdate(k => k.EventTitle, e));
            context.SaveChanges();
        }
    }
}
