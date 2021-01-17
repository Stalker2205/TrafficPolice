namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatRank : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        RankID = c.Int(nullable: false, identity: true),
                        RankName = c.String(),
                        RankPhoto = c.String(),
                        Staff_StaffID = c.Int(),
                    })
                .PrimaryKey(t => t.RankID)
                .ForeignKey("dbo.Staffs", t => t.Staff_StaffID)
                .Index(t => t.Staff_StaffID);
            
            AddColumn("dbo.Staffs", "RankID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ranks", "Staff_StaffID", "dbo.Staffs");
            DropIndex("dbo.Ranks", new[] { "Staff_StaffID" });
            DropColumn("dbo.Staffs", "RankID");
            DropTable("dbo.Ranks");
        }
    }
}
