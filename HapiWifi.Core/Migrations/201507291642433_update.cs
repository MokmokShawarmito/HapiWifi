namespace HapiWifi.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "BannerImagePath", c => c.String());
            AddColumn("dbo.Companies", "LogoImagePath", c => c.String());
            DropColumn("dbo.Companies", "PicBanner");
            DropColumn("dbo.Companies", "PicLogo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "PicLogo", c => c.String());
            AddColumn("dbo.Companies", "PicBanner", c => c.String());
            DropColumn("dbo.Companies", "LogoImagePath");
            DropColumn("dbo.Companies", "BannerImagePath");
        }
    }
}
