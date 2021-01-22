namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInsurance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Insurances", "InsuranceID", "dbo.Drivers");
            DropIndex("dbo.Insurances", new[] { "InsuranceID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Insurances", "InsuranceID");
            AddForeignKey("dbo.Insurances", "InsuranceID", "dbo.Drivers", "DriverID");
        }
    }
}
