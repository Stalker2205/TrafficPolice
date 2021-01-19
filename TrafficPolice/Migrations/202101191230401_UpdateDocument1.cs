namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDocument1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InsuranceDocuments", "Insurance_InsuranceID", "dbo.Insurances");
            DropForeignKey("dbo.InsuranceDocuments", "Document_DocumentID", "dbo.Documents");
            DropIndex("dbo.InsuranceDocuments", new[] { "Insurance_InsuranceID" });
            DropIndex("dbo.InsuranceDocuments", new[] { "Document_DocumentID" });
            AddColumn("dbo.Insurances", "Document_DocumentID", c => c.Int());
            CreateIndex("dbo.Insurances", "Document_DocumentID");
            AddForeignKey("dbo.Insurances", "Document_DocumentID", "dbo.Documents", "DocumentID");
            DropTable("dbo.InsuranceDocuments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InsuranceDocuments",
                c => new
                    {
                        Insurance_InsuranceID = c.Int(nullable: false),
                        Document_DocumentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Insurance_InsuranceID, t.Document_DocumentID });
            
            DropForeignKey("dbo.Insurances", "Document_DocumentID", "dbo.Documents");
            DropIndex("dbo.Insurances", new[] { "Document_DocumentID" });
            DropColumn("dbo.Insurances", "Document_DocumentID");
            CreateIndex("dbo.InsuranceDocuments", "Document_DocumentID");
            CreateIndex("dbo.InsuranceDocuments", "Insurance_InsuranceID");
            AddForeignKey("dbo.InsuranceDocuments", "Document_DocumentID", "dbo.Documents", "DocumentID", cascadeDelete: true);
            AddForeignKey("dbo.InsuranceDocuments", "Insurance_InsuranceID", "dbo.Insurances", "InsuranceID", cascadeDelete: true);
        }
    }
}
