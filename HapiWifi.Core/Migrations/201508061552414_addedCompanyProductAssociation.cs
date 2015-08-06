namespace HapiWifi.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCompanyProductAssociation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Products", "CompanyId");
            AddForeignKey("dbo.Products", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Products", new[] { "CompanyId" });
        }
    }
}
