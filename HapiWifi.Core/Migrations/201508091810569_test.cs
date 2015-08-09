namespace HapiWifi.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                        Type = c.String(),
                        ImagePath = c.String(),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TagLine = c.String(),
                        Description = c.String(),
                        Type = c.String(),
                        BannerImagePath = c.String(),
                        LogoImagePath = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Partnerships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        companyID = c.Int(nullable: false),
                        partnerID = c.Int(nullable: false),
                        partnerOrder = c.Int(nullable: false),
                        isShow = c.Boolean(nullable: false),
                        isFeatured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order = c.Int(nullable: false),
                        isShow = c.Boolean(nullable: false),
                        ImagePath = c.String(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Branches", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Products", new[] { "CompanyId" });
            DropIndex("dbo.Branches", new[] { "CompanyID" });
            DropTable("dbo.Products");
            DropTable("dbo.Partnerships");
            DropTable("dbo.Companies");
            DropTable("dbo.Branches");
        }
    }
}
