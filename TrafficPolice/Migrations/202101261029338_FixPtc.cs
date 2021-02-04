namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPtc : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Ptcs", name: "CtcID", newName: "PtcID");
            RenameIndex(table: "dbo.Ptcs", name: "IX_CtcID", newName: "IX_PtcID");
            AddColumn("dbo.Ptcs", "PtcNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Ptcs", "PtcSeries", c => c.Int(nullable: false));
            DropColumn("dbo.Ptcs", "CtcNumber");
            DropColumn("dbo.Ptcs", "CtcSeries");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ptcs", "CtcSeries", c => c.Int(nullable: false));
            AddColumn("dbo.Ptcs", "CtcNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Ptcs", "PtcSeries");
            DropColumn("dbo.Ptcs", "PtcNumber");
            RenameIndex(table: "dbo.Ptcs", name: "IX_PtcID", newName: "IX_CtcID");
            RenameColumn(table: "dbo.Ptcs", name: "PtcID", newName: "CtcID");
        }
    }
}
