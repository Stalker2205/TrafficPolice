namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeliteWorkSchedule : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "StaffID", "dbo.WorkSchedules");
            DropIndex("dbo.Staffs", new[] { "StaffID" });
            DropColumn("dbo.WorkSchedules", "StaffID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkSchedules", "StaffID", c => c.Int(nullable: false));
            CreateIndex("dbo.Staffs", "StaffID");
            AddForeignKey("dbo.Staffs", "StaffID", "dbo.WorkSchedules", "WorkScheduleID");
        }
    }
}
