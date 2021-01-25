namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelitePosition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "PositionID", "dbo.WorkSchedules");
            DropIndex("dbo.Positions", new[] { "PositionID" });
            DropColumn("dbo.WorkSchedules", "PositionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkSchedules", "PositionID", c => c.Int(nullable: false));
            CreateIndex("dbo.Positions", "PositionID");
            AddForeignKey("dbo.Positions", "PositionID", "dbo.WorkSchedules", "WorkScheduleID");
        }
    }
}
