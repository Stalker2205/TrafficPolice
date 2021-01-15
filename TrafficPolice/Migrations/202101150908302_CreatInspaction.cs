namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatInspaction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InsuranceDocuments", "Insurance_InsuranceID", "dbo.Insurances");
            DropIndex("dbo.Insurances", new[] { "InsuranceID" });
            DropPrimaryKey("dbo.Insurances");
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        InspectionID = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                        EndDate = c.DateTime(nullable: false),
                        PlaceOfInspaction = c.String(),
                        Vin = c.String(),
                        ChossisNumber = c.Int(nullable: false),
                        BodyNumber = c.Int(nullable: false),
                        Model = c.String(),
                        Malfunctions = c.String(),
                        UsingCar = c.Boolean(nullable: false),
                        Document_DocumentID = c.Int(),
                    })
                .PrimaryKey(t => t.InspectionID)
                .ForeignKey("dbo.Documents", t => t.Document_DocumentID)
                .Index(t => t.Document_DocumentID);
            
            AlterColumn("dbo.Insurances", "InsuranceID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Insurances", "InsuranceID");
            CreateIndex("dbo.Insurances", "InsuranceID");
            AddForeignKey("dbo.InsuranceDocuments", "Insurance_InsuranceID", "dbo.Insurances", "InsuranceID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsuranceDocuments", "Insurance_InsuranceID", "dbo.Insurances");
            DropForeignKey("dbo.Inspections", "Document_DocumentID", "dbo.Documents");
            DropIndex("dbo.Insurances", new[] { "InsuranceID" });
            DropIndex("dbo.Inspections", new[] { "Document_DocumentID" });
            DropPrimaryKey("dbo.Insurances");
            AlterColumn("dbo.Insurances", "InsuranceID", c => c.Int(nullable: false));
            DropTable("dbo.Inspections");
            AddPrimaryKey("dbo.Insurances", "InsuranceID");
            CreateIndex("dbo.Insurances", "InsuranceID");
            AddForeignKey("dbo.InsuranceDocuments", "Insurance_InsuranceID", "dbo.Insurances", "InsuranceID", cascadeDelete: true);
        }
    }
}
