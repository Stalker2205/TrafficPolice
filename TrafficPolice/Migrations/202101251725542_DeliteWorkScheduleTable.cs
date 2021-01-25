namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeliteWorkScheduleTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.WorkSchedules");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkSchedules",
                c => new
                    {
                        WorkScheduleID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.WorkScheduleID);
            
        }
    }
}
