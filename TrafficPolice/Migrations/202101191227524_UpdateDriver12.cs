namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDriver12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "Insurance_InsuranceID", "dbo.Insurances");
            DropIndex("dbo.Drivers", new[] { "Insurance_InsuranceID" });
            RenameColumn(table: "dbo.Ptcs", name: "CtcID", newName: "PtcID");
            RenameIndex(table: "dbo.Ptcs", name: "IX_CtcID", newName: "IX_PtcID");
            AddColumn("dbo.Ptcs", "PtcNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Ptcs", "PtcSeries", c => c.Int(nullable: false));
            DropColumn("dbo.Ptcs", "CtcNumber");
            DropColumn("dbo.Ptcs", "CtcSeries");
            DropColumn("dbo.Drivers", "Insurance_InsuranceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "Insurance_InsuranceID", c => c.Int());
            AddColumn("dbo.Ptcs", "CtcSeries", c => c.Int(nullable: false));
            AddColumn("dbo.Ptcs", "CtcNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Ptcs", "PtcSeries");
            DropColumn("dbo.Ptcs", "PtcNumber");
            RenameIndex(table: "dbo.Ptcs", name: "IX_PtcID", newName: "IX_CtcID");
            RenameColumn(table: "dbo.Ptcs", name: "PtcID", newName: "CtcID");
            CreateIndex("dbo.Drivers", "Insurance_InsuranceID");
            AddForeignKey("dbo.Drivers", "Insurance_InsuranceID", "dbo.Insurances", "InsuranceID");
        }
    }
}
