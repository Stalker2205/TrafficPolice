namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCTC : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ctcs", "CtcSeries", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ctcs", "CtcSeries", c => c.Int(nullable: false));
        }
    }
}
