namespace HikersConnection.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HikersConnection.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HikersConnection.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HikersConnection.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            /*
            var hikers = new List<Hiker>
            {
                new Hiker { FirstName = "Ali", LastName = "Hill" },
                new Hiker { FirstName = "Lucy", LastName = "Hill" }
            };
            hikers.ForEach(h => context.Hikers.AddOrUpdate(p => p.FullName, h));
            context.SaveChanges();
            */
            var ageGroups = new List<AgeGroup>
            {
                new AgeGroup { Group = "Under 5" },
                new AgeGroup { Group = "5 - 10" },
                new AgeGroup { Group = "10 - 20" },
                new AgeGroup { Group = "20 - 45" },
                new AgeGroup { Group = "45 - 55" },
                new AgeGroup { Group = "Over 55" }
            };
            ageGroups.ForEach(h => context.AgeGroups.AddOrUpdate(p => p.Group, h));
            context.SaveChanges();
        }
    }
}
