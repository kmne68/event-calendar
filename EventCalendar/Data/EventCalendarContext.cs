using EventCalendar.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EventCalendar.Data
{
    public class EventCalendarContext : IdentityDbContext<ApplicationUser>
    {
        public EventCalendarContext(): base("EventCalendarContext")
        {
        }

        public static EventCalendarContext Create()
        {
            return new EventCalendarContext();
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Set db tables names to be singular
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /// Added to fix "no keys defined error" when adding migrations
            base.OnModelCreating(modelBuilder);

            //---- Customize names in the database
            // Rename ApplicationUser to Member and use MemberID as primary key
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(p => p.Id).HasColumnName("UserID");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim").Property(p => p.Id).HasColumnName("UserClaimID");
            modelBuilder.Entity<IdentityRole>().ToTable("Role").Property(p => p.Id).HasColumnName("RoleID");

        }

    }
}