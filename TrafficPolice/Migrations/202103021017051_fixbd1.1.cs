namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixbd11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", "Car_CarID", "dbo.Cars");
            DropIndex("dbo.Documents", new[] { "Car_CarID" });
            DropColumn("dbo.Documents", "Car_CarID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "Car_CarID", c => c.Int());
            CreateIndex("dbo.Documents", "Car_CarID");
            AddForeignKey("dbo.Documents", "Car_CarID", "dbo.Cars", "CarID");
        }
    }
}
