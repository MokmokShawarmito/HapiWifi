namespace HapiWifi.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "ImagePath", c => c.String());
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            CreateIndex("dbo.Branches", "CompanyID");
            AddForeignKey("dbo.Branches", "CompanyID", "dbo.Companies", "Id", cascadeDelete: true);
            DropColumn("dbo.Branches", "Image");
            DropColumn("dbo.Products", "isFeatured");
            DropColumn("dbo.Products", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Image", c => c.String());
            AddColumn("dbo.Products", "isFeatured", c => c.Boolean(nullable: false));
            AddColumn("dbo.Branches", "Image", c => c.String());
            DropForeignKey("dbo.Branches", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Branches", new[] { "CompanyID" });
            DropColumn("dbo.Products", "ImagePath");
            DropColumn("dbo.Branches", "ImagePath");
        }
    }
}
