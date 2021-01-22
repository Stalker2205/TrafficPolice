namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ctcs", "CtcID", "dbo.Documents");
            DropForeignKey("dbo.Inspections", "Document_DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Insurances", "Document_DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Ptcs", "PtcID", "dbo.Documents");
            DropForeignKey("dbo.Statements", "Document_DocumentID", "dbo.Documents");
            DropIndex("dbo.Documents", new[] { "DocumentID" });
            DropIndex("dbo.Ctcs", new[] { "CtcID" });
            DropPrimaryKey("dbo.Documents");
            AddColumn("dbo.Ctcs", "Document_DocumentID", c => c.Int());
            AlterColumn("dbo.Documents", "DocumentID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Documents", "DocumentID");
            CreateIndex("dbo.Documents", "DocumentID");
            CreateIndex("dbo.Ctcs", "Document_DocumentID");
            AddForeignKey("dbo.Ctcs", "Document_DocumentID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Inspections", "Document_DocumentID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Insurances", "Document_DocumentID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Ptcs", "PtcID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Statements", "Document_DocumentID", "dbo.Documents", "DocumentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statements", "Document_DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Ptcs", "PtcID", "dbo.Documents");
            DropForeignKey("dbo.Insurances", "Document_DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Inspections", "Document_DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Ctcs", "Document_DocumentID", "dbo.Documents");
            DropIndex("dbo.Ctcs", new[] { "Document_DocumentID" });
            DropIndex("dbo.Documents", new[] { "DocumentID" });
            DropPrimaryKey("dbo.Documents");
            AlterColumn("dbo.Documents", "DocumentID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Ctcs", "Document_DocumentID");
            AddPrimaryKey("dbo.Documents", "DocumentID");
            CreateIndex("dbo.Ctcs", "CtcID");
            CreateIndex("dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Statements", "Document_DocumentID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Ptcs", "PtcID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Insurances", "Document_DocumentID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Inspections", "Document_DocumentID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Ctcs", "CtcID", "dbo.Documents", "DocumentID");
        }
    }
}
