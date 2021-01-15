namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatPtc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ptcs",
                c => new
                    {
                        CtcID = c.Int(nullable: false, identity: true),
                        CtcNumber = c.Int(nullable: false),
                        CtcSeries = c.Int(nullable: false),
                        YearOfManufacture = c.Int(nullable: false),
                        EngineVolume = c.Int(nullable: false),
                        EngineType = c.String(),
                        EcoClass = c.String(),
                        Manufacture = c.String(),
                        CustomsRestrictions = c.String(),
                        DateOut = c.String(),
                    })
                .PrimaryKey(t => t.CtcID)
                .ForeignKey("dbo.Documents", t => t.CtcID)
                .Index(t => t.CtcID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ptcs", "CtcID", "dbo.Documents");
            DropIndex("dbo.Ptcs", new[] { "CtcID" });
            DropTable("dbo.Ptcs");
        }
    }
}
