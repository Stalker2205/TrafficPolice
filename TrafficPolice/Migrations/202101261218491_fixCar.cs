namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCar : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Driver_DriverID", "dbo.Drivers");
            DropIndex("dbo.Cars", new[] { "Driver_DriverID" });
            RenameColumn(table: "dbo.Cars", name: "Driver_DriverID", newName: "DriverID");
            AlterColumn("dbo.Cars", "DriverID", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "DriverID");
            AddForeignKey("dbo.Cars", "DriverID", "dbo.Drivers", "DriverID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "DriverID", "dbo.Drivers");
            DropIndex("dbo.Cars", new[] { "DriverID" });
            AlterColumn("dbo.Cars", "DriverID", c => c.Int());
            RenameColumn(table: "dbo.Cars", name: "DriverID", newName: "Driver_DriverID");
            CreateIndex("dbo.Cars", "Driver_DriverID");
            AddForeignKey("dbo.Cars", "Driver_DriverID", "dbo.Drivers", "DriverID");
        }
    }
}
