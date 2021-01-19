namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDriverInCar : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "DriverID", "dbo.Cars");
            DropIndex("dbo.Drivers", new[] { "DriverID" });
            AddColumn("dbo.Cars", "Driver_DriverID", c => c.Int());
            CreateIndex("dbo.Cars", "Driver_DriverID");
            AddForeignKey("dbo.Cars", "Driver_DriverID", "dbo.Drivers", "DriverID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Driver_DriverID", "dbo.Drivers");
            DropIndex("dbo.Cars", new[] { "Driver_DriverID" });
            DropColumn("dbo.Cars", "Driver_DriverID");
            CreateIndex("dbo.Drivers", "DriverID");
            AddForeignKey("dbo.Drivers", "DriverID", "dbo.Cars", "CarID");
        }
    }
}
