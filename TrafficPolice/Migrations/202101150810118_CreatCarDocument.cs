namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatCarDocument : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Passports", new[] { "PassportID" });
            DropPrimaryKey("dbo.Passports");
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        VenhicleType = c.String(),
                        EngineNumber = c.Int(nullable: false),
                        ChossisNumber = c.Int(nullable: false),
                        BodyNumber = c.Int(nullable: false),
                        Color = c.String(),
                        MaxVeigh = c.Int(nullable: false),
                        Vin = c.String(),
                    })
                .PrimaryKey(t => t.CarID);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("dbo.Cars", t => t.DocumentID)
                .Index(t => t.DocumentID);
            
            AlterColumn("dbo.Passports", "PassportID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Passports", "PassportID");
            CreateIndex("dbo.Drivers", "DriverID");
            CreateIndex("dbo.Passports", "PassportID");
            AddForeignKey("dbo.Drivers", "DriverID", "dbo.Cars", "CarID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "DriverID", "dbo.Cars");
            DropForeignKey("dbo.Documents", "DocumentID", "dbo.Cars");
            DropIndex("dbo.Passports", new[] { "PassportID" });
            DropIndex("dbo.Documents", new[] { "DocumentID" });
            DropIndex("dbo.Drivers", new[] { "DriverID" });
            DropPrimaryKey("dbo.Passports");
            AlterColumn("dbo.Passports", "PassportID", c => c.Int(nullable: false));
            DropTable("dbo.Documents");
            DropTable("dbo.Cars");
            AddPrimaryKey("dbo.Passports", "PassportID");
            CreateIndex("dbo.Passports", "PassportID");
        }
    }
}
