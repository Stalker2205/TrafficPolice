namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatPositionAndWork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        PositionName = c.String(),
                    })
                .PrimaryKey(t => t.PositionID)
                .ForeignKey("dbo.WorkSchedules", t => t.PositionID)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.WorkSchedules",
                c => new
                    {
                        WorkScheduleID = c.Int(nullable: false, identity: true),
                        StaffID = c.Int(nullable: false),
                        PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkScheduleID);
            
            CreateIndex("dbo.Staffs", "StaffID");
            AddForeignKey("dbo.Staffs", "StaffID", "dbo.WorkSchedules", "WorkScheduleID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "PositionID", "dbo.WorkSchedules");
            DropForeignKey("dbo.Staffs", "StaffID", "dbo.WorkSchedules");
            DropIndex("dbo.Staffs", new[] { "StaffID" });
            DropIndex("dbo.Positions", new[] { "PositionID" });
            DropTable("dbo.WorkSchedules");
            DropTable("dbo.Positions");
        }
    }
}
