namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixStaff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sertifications", "Staff_StaffID", "dbo.Staffs");
            DropIndex("dbo.Sertifications", new[] { "Staff_StaffID" });
            DropColumn("dbo.Staffs", "SertificationID");
            DropColumn("dbo.Sertifications", "Staff_StaffID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sertifications", "Staff_StaffID", c => c.Int());
            AddColumn("dbo.Staffs", "SertificationID", c => c.Int());
            CreateIndex("dbo.Sertifications", "Staff_StaffID");
            AddForeignKey("dbo.Sertifications", "Staff_StaffID", "dbo.Staffs", "StaffID");
        }
    }
}
