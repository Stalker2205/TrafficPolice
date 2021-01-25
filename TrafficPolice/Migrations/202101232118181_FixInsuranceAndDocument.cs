namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixInsuranceAndDocument : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InsuranceDocuments", "Insurance_InsuranceID", "dbo.Insurances");
            DropForeignKey("dbo.InsuranceDocuments", "Document_DocumentID", "dbo.Documents");
            DropIndex("dbo.InsuranceDocuments", new[] { "Insurance_InsuranceID" });
            DropIndex("dbo.InsuranceDocuments", new[] { "Document_DocumentID" });
            DropPrimaryKey("dbo.Insurances");
            AlterColumn("dbo.Insurances", "InsuranceID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Insurances", "InsuranceID");
            CreateIndex("dbo.Insurances", "InsuranceID");
            AddForeignKey("dbo.Insurances", "InsuranceID", "dbo.Documents", "DocumentID");
            DropColumn("dbo.Documents", "InsuranceID");
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
            
            AddColumn("dbo.Documents", "InsuranceID", c => c.Int());
            DropForeignKey("dbo.Insurances", "InsuranceID", "dbo.Documents");
            DropIndex("dbo.Insurances", new[] { "InsuranceID" });
            DropPrimaryKey("dbo.Insurances");
            AlterColumn("dbo.Insurances", "InsuranceID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Insurances", "InsuranceID");
            CreateIndex("dbo.InsuranceDocuments", "Document_DocumentID");
            CreateIndex("dbo.InsuranceDocuments", "Insurance_InsuranceID");
            AddForeignKey("dbo.InsuranceDocuments", "Document_DocumentID", "dbo.Documents", "DocumentID", cascadeDelete: true);
            AddForeignKey("dbo.InsuranceDocuments", "Insurance_InsuranceID", "dbo.Insurances", "InsuranceID", cascadeDelete: true);
        }
    }
}
