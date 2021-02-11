namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCTCandPTC : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Ctcs", new[] { "CtcID" });
            DropIndex("dbo.Ptcs", new[] { "PtcID" });
            DropPrimaryKey("dbo.Ctcs");
            DropPrimaryKey("dbo.Ptcs");
            AlterColumn("dbo.Ctcs", "CtcID", c => c.Int(nullable: false));
            AlterColumn("dbo.Ptcs", "PtcID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Ctcs", "CtcID");
            AddPrimaryKey("dbo.Ptcs", "PtcID");
            CreateIndex("dbo.Ctcs", "CtcID");
            CreateIndex("dbo.Ptcs", "PtcID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ptcs", new[] { "PtcID" });
            DropIndex("dbo.Ctcs", new[] { "CtcID" });
            DropPrimaryKey("dbo.Ptcs");
            DropPrimaryKey("dbo.Ctcs");
            AlterColumn("dbo.Ptcs", "PtcID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Ctcs", "CtcID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Ptcs", "PtcID");
            AddPrimaryKey("dbo.Ctcs", "CtcID");
            CreateIndex("dbo.Ptcs", "PtcID");
            CreateIndex("dbo.Ctcs", "CtcID");
        }
    }
}
