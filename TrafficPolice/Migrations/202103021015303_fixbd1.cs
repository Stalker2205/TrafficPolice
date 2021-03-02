namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixbd1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", "DocumentID", "dbo.Cars");
            DropIndex("dbo.Documents", new[] { "DocumentID" });
            AddColumn("dbo.Documents", "Car_CarID", c => c.Int());
            CreateIndex("dbo.Documents", "Car_CarID");
            AddForeignKey("dbo.Documents", "Car_CarID", "dbo.Cars", "CarID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "Car_CarID", "dbo.Cars");
            DropIndex("dbo.Documents", new[] { "Car_CarID" });
            DropColumn("dbo.Documents", "Car_CarID");
            CreateIndex("dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Documents", "DocumentID", "dbo.Cars", "CarID");
        }
    }
}
