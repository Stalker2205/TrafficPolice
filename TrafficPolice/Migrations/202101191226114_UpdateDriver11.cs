namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDriver11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Insurances", "Document_DocumentID", "dbo.Documents");
            DropIndex("dbo.Insurances", new[] { "Document_DocumentID" });
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
            
            AddColumn("dbo.Drivers", "Insurance_InsuranceID", c => c.Int());
            CreateIndex("dbo.Drivers", "Insurance_InsuranceID");
            AddForeignKey("dbo.Drivers", "Insurance_InsuranceID", "dbo.Insurances", "InsuranceID");
            DropColumn("dbo.Insurances", "Document_DocumentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Insurances", "Document_DocumentID", c => c.Int());
            DropForeignKey("dbo.Drivers", "Insurance_InsuranceID", "dbo.Insurances");
            DropForeignKey("dbo.InsuranceDocuments", "Document_DocumentID", "dbo.Documents");
            DropForeignKey("dbo.InsuranceDocuments", "Insurance_InsuranceID", "dbo.Insurances");
            DropIndex("dbo.InsuranceDocuments", new[] { "Document_DocumentID" });
            DropIndex("dbo.InsuranceDocuments", new[] { "Insurance_InsuranceID" });
            DropIndex("dbo.Drivers", new[] { "Insurance_InsuranceID" });
            DropColumn("dbo.Drivers", "Insurance_InsuranceID");
            DropTable("dbo.InsuranceDocuments");
            CreateIndex("dbo.Insurances", "Document_DocumentID");
            AddForeignKey("dbo.Insurances", "Document_DocumentID", "dbo.Documents", "DocumentID");
        }
    }
}
