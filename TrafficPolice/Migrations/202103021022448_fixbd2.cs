namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixbd2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inspections", "DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Insurances", "InsuranceID", "dbo.Documents");
            DropForeignKey("dbo.Ptcs", "PtcID", "dbo.Documents");
            DropForeignKey("dbo.Statements", "DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Ctcs", "CtcID", "dbo.Documents");
            DropIndex("dbo.Ctcs", new[] { "CtcID" });
            DropIndex("dbo.Inspections", new[] { "DocumentID" });
            DropIndex("dbo.Insurances", new[] { "InsuranceID" });
            DropIndex("dbo.Ptcs", new[] { "PtcID" });
            DropIndex("dbo.Statements", new[] { "DocumentID" });
            DropColumn("dbo.Documents", "StatementsID");
            DropColumn("dbo.Documents", "InspectionID");
            DropColumn("dbo.Inspections", "DocumentID");
            DropColumn("dbo.Statements", "DocumentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Statements", "DocumentID", c => c.Int(nullable: false));
            AddColumn("dbo.Inspections", "DocumentID", c => c.Int(nullable: false));
            AddColumn("dbo.Documents", "InspectionID", c => c.Int());
            AddColumn("dbo.Documents", "StatementsID", c => c.Int());
            CreateIndex("dbo.Statements", "DocumentID");
            CreateIndex("dbo.Ptcs", "PtcID");
            CreateIndex("dbo.Insurances", "InsuranceID");
            CreateIndex("dbo.Inspections", "DocumentID");
            CreateIndex("dbo.Ctcs", "CtcID");
            AddForeignKey("dbo.Ctcs", "CtcID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Statements", "DocumentID", "dbo.Documents", "DocumentID", cascadeDelete: true);
            AddForeignKey("dbo.Ptcs", "PtcID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Insurances", "InsuranceID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Inspections", "DocumentID", "dbo.Documents", "DocumentID", cascadeDelete: true);
        }
    }
}
