namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRankAndStaff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ranks", "Staff_StaffID", "dbo.Staffs");
            DropIndex("dbo.Ranks", new[] { "Staff_StaffID" });
            CreateIndex("dbo.Staffs", "RankID");
            AddForeignKey("dbo.Staffs", "RankID", "dbo.Ranks", "RankID", cascadeDelete: true);
            DropColumn("dbo.Ranks", "Staff_StaffID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ranks", "Staff_StaffID", c => c.Int());
            DropForeignKey("dbo.Staffs", "RankID", "dbo.Ranks");
            DropIndex("dbo.Staffs", new[] { "RankID" });
            CreateIndex("dbo.Ranks", "Staff_StaffID");
            AddForeignKey("dbo.Ranks", "Staff_StaffID", "dbo.Staffs", "StaffID");
        }
    }
}
