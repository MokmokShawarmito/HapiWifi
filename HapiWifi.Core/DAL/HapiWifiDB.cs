namespace HapiWifi.Core.DAL
{
    using HapiWifi.Core.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HapiWifiDB : DbContext
    {
        public HapiWifiDB()
            : base("name=HapiWifiDB")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Partnership> Partnerships { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
    }
}