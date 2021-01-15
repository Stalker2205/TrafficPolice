namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatCtc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ctcs",
                c => new
                    {
                        CtcID = c.Int(nullable: false, identity: true),
                        CtcNumber = c.Int(nullable: false),
                        CtcSeries = c.Int(nullable: false),
                        Owner = c.Int(nullable: false),
                        DateOfIssue = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CtcID)
                .ForeignKey("dbo.Documents", t => t.CtcID)
                .Index(t => t.CtcID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ctcs", "CtcID", "dbo.Documents");
            DropIndex("dbo.Ctcs", new[] { "CtcID" });
            DropTable("dbo.Ctcs");
        }
    }
}
