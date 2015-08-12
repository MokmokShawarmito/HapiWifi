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
            AutomaticMigrationDataLossAllowed = true; 
        }

        protected override void Seed(HapiWifi.Core.DAL.HapiWifiDB context)
        {
            //  This method will be called after migrating to the latest version.
            context.Companies.AddOrUpdate(c => c.Id,
                new Company() { 
                    Id = 1,
                    Name = "ATENEO TEST", 
                    TagLine = "Ate ne eyo de churva la pakaka.",
                    Type = "advertiser",
                    Website = "http://xxx.xxx",
                    LogoImagePath = "/images/uploads/logo/ateneo-812015732pm.png",
                    BannerImagePath = "/images/uploads/banner/ateneo-812015732pm.png",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                }
            );

            context.SaveChanges();
        }

    }
}
