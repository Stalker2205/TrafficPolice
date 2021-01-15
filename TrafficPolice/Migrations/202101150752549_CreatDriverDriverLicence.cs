namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatDriverDriverLicence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverID = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        FirstName = c.String(),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.DriverID);
            
            CreateTable(
                "dbo.DriversLicenses",
                c => new
                    {
                        DriversLicenseID = c.Int(nullable: false, identity: true),
                        DriversLicenseNumber = c.Int(nullable: false),
                        DriversLicenseSeries = c.Int(nullable: false),
                        Category = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Driver_DriverID = c.Int(),
                    })
                .PrimaryKey(t => t.DriversLicenseID)
                .ForeignKey("dbo.Drivers", t => t.Driver_DriverID)
                .Index(t => t.Driver_DriverID);
            
            CreateTable(
                "dbo.Passports",
                c => new
                    {
                        PassportID = c.Int(nullable: false, identity: true),
                        PassportNumber = c.Int(nullable: false),
                        PassportSeries = c.Int(nullable: false),
                        PassportAdress = c.String(),
                        DateOfIssue = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PassportID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DriversLicenses", "Driver_DriverID", "dbo.Drivers");
            DropIndex("dbo.DriversLicenses", new[] { "Driver_DriverID" });
            DropTable("dbo.Passports");
            DropTable("dbo.DriversLicenses");
            DropTable("dbo.Drivers");
        }
    }
}
