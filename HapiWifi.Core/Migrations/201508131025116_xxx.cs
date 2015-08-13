namespace HapiWifi.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Page = c.String(),
                        Date = c.DateTime(nullable: false),
                        Browser = c.String(),
                        IsMobileRequest = c.Boolean(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "isFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "isFeatured");
            DropTable("dbo.RequestLogs");
        }
    }
}
