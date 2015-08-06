namespace HapiWifi.Core.Migrations
{
    using HapiWifi.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HapiWifi.Core.DAL.HapiWifiDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false; 
        }

        protected override void Seed(HapiWifi.Core.DAL.HapiWifiDB context)
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

            context.Companies.AddOrUpdate(c => c.Id,
                new Company() { Id = 1, Name="Test",TagLine="Test",Type="Test",Website="Test",LogoImagePath="Test",Description="Test",BannerImagePath="Test" }
                );

            context.SaveChanges();
        }

    }
}
