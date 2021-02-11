namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixPtc1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ptcs", "PtcSeries", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ptcs", "PtcSeries", c => c.Int(nullable: false));
        }
    }
}
