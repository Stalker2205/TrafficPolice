namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixStaff1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sertifications", "StaffID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sertifications", "StaffID");
            AddForeignKey("dbo.Sertifications", "StaffID", "dbo.Staffs", "StaffID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sertifications", "StaffID", "dbo.Staffs");
            DropIndex("dbo.Sertifications", new[] { "StaffID" });
            DropColumn("dbo.Sertifications", "StaffID");
        }
    }
}
