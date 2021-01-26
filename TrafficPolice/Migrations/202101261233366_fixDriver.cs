namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDriver : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DriversLicenses", "Driver_DriverID", "dbo.Drivers");
            DropIndex("dbo.DriversLicenses", new[] { "Driver_DriverID" });
            RenameColumn(table: "dbo.DriversLicenses", name: "Driver_DriverID", newName: "DriverID");
            AlterColumn("dbo.DriversLicenses", "DriverID", c => c.Int(nullable: false));
            CreateIndex("dbo.DriversLicenses", "DriverID");
            AddForeignKey("dbo.DriversLicenses", "DriverID", "dbo.Drivers", "DriverID", cascadeDelete: true);
            DropColumn("dbo.Drivers", "DriversLicenseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "DriversLicenseID", c => c.Int());
            DropForeignKey("dbo.DriversLicenses", "DriverID", "dbo.Drivers");
            DropIndex("dbo.DriversLicenses", new[] { "DriverID" });
            AlterColumn("dbo.DriversLicenses", "DriverID", c => c.Int());
            RenameColumn(table: "dbo.DriversLicenses", name: "DriverID", newName: "Driver_DriverID");
            CreateIndex("dbo.DriversLicenses", "Driver_DriverID");
            AddForeignKey("dbo.DriversLicenses", "Driver_DriverID", "dbo.Drivers", "DriverID");
        }
    }
}
