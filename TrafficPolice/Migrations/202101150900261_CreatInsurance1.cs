namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatInsurance1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", "Insurance_InsuranceID", "dbo.Insurances");
            DropIndex("dbo.Documents", new[] { "Insurance_InsuranceID" });
            CreateTable(
                "dbo.InsuranceDocuments",
                c => new
                    {
                        Insurance_InsuranceID = c.Int(nullable: false),
                        Document_DocumentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Insurance_InsuranceID, t.Document_DocumentID })
                .ForeignKey("dbo.Insurances", t => t.Insurance_InsuranceID, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.Document_DocumentID, cascadeDelete: true)
                .Index(t => t.Insurance_InsuranceID)
                .Index(t => t.Document_DocumentID);
            
            DropColumn("dbo.Documents", "Insurance_InsuranceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "Insurance_InsuranceID", c => c.Int());
            DropForeignKey("dbo.InsuranceDocuments", "Document_DocumentID", "dbo.Documents");
            DropForeignKey("dbo.InsuranceDocuments", "Insurance_InsuranceID", "dbo.Insurances");
            DropIndex("dbo.InsuranceDocuments", new[] { "Document_DocumentID" });
            DropIndex("dbo.InsuranceDocuments", new[] { "Insurance_InsuranceID" });
            DropTable("dbo.InsuranceDocuments");
            CreateIndex("dbo.Documents", "Insurance_InsuranceID");
            AddForeignKey("dbo.Documents", "Insurance_InsuranceID", "dbo.Insurances", "InsuranceID");
        }
    }
}
