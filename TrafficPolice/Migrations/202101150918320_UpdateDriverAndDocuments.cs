namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDriverAndDocuments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "StatementsID", c => c.Int());
            AddColumn("dbo.Documents", "InsuranceID", c => c.Int());
            AddColumn("dbo.Documents", "InspectionID", c => c.Int());
            AddColumn("dbo.Drivers", "DriversLicenseID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "DriversLicenseID");
            DropColumn("dbo.Documents", "InspectionID");
            DropColumn("dbo.Documents", "InsuranceID");
            DropColumn("dbo.Documents", "StatementsID");
        }
    }
}
