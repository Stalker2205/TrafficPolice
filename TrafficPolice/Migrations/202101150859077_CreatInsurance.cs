namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatInsurance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        InsuranceID = c.Int(nullable: false),
                        InsuranceNumber = c.Int(nullable: false),
                        InsuranceSeries = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Insurant = c.String(),
                    })
                .PrimaryKey(t => t.InsuranceID)
                .ForeignKey("dbo.Drivers", t => t.InsuranceID)
                .Index(t => t.InsuranceID);
            
            AddColumn("dbo.Documents", "Insurance_InsuranceID", c => c.Int());
            CreateIndex("dbo.Documents", "Insurance_InsuranceID");
            AddForeignKey("dbo.Documents", "Insurance_InsuranceID", "dbo.Insurances", "InsuranceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insurances", "InsuranceID", "dbo.Drivers");
            DropForeignKey("dbo.Documents", "Insurance_InsuranceID", "dbo.Insurances");
            DropIndex("dbo.Insurances", new[] { "InsuranceID" });
            DropIndex("dbo.Documents", new[] { "Insurance_InsuranceID" });
            DropColumn("dbo.Documents", "Insurance_InsuranceID");
            DropTable("dbo.Insurances");
        }
    }
}
