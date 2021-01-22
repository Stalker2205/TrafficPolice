namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCtcPtcStaffCarDocument : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Ptcs", name: "CtcID", newName: "PtcID");
            RenameIndex(table: "dbo.Ptcs", name: "IX_CtcID", newName: "IX_PtcID");
            AddColumn("dbo.Cars", "DocumentID", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "DriverID", c => c.Int(nullable: false));
            AddColumn("dbo.Documents", "CtcID", c => c.Int(nullable: false));
            AddColumn("dbo.Documents", "PtcID", c => c.Int(nullable: false));
            AddColumn("dbo.Ptcs", "PtcNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Ptcs", "PtcSeries", c => c.Int(nullable: false));
            AddColumn("dbo.Staffs", "WorkScheduleID", c => c.Int(nullable: false));
            DropColumn("dbo.Ptcs", "CtcNumber");
            DropColumn("dbo.Ptcs", "CtcSeries");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ptcs", "CtcSeries", c => c.Int(nullable: false));
            AddColumn("dbo.Ptcs", "CtcNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Staffs", "WorkScheduleID");
            DropColumn("dbo.Ptcs", "PtcSeries");
            DropColumn("dbo.Ptcs", "PtcNumber");
            DropColumn("dbo.Documents", "PtcID");
            DropColumn("dbo.Documents", "CtcID");
            DropColumn("dbo.Cars", "DriverID");
            DropColumn("dbo.Cars", "DocumentID");
            RenameIndex(table: "dbo.Ptcs", name: "IX_PtcID", newName: "IX_CtcID");
            RenameColumn(table: "dbo.Ptcs", name: "PtcID", newName: "CtcID");
        }
    }
}
