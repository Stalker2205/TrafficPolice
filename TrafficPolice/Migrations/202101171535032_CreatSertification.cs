namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatSertification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Lastname = c.String(),
                        Photo = c.String(),
                        Education = c.String(),
                        SertificationID = c.Int(),
                    })
                .PrimaryKey(t => t.StaffID);
            
            CreateTable(
                "dbo.Sertifications",
                c => new
                    {
                        SertificationID = c.Int(nullable: false, identity: true),
                        SertificationNumber = c.Int(nullable: false),
                        SertificationSeries = c.Int(nullable: false),
                        SertificationPosition = c.String(),
                        ValidUnit = c.DateTime(nullable: false),
                        Staff_StaffID = c.Int(),
                    })
                .PrimaryKey(t => t.SertificationID)
                .ForeignKey("dbo.Staffs", t => t.Staff_StaffID)
                .Index(t => t.Staff_StaffID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sertifications", "Staff_StaffID", "dbo.Staffs");
            DropIndex("dbo.Sertifications", new[] { "Staff_StaffID" });
            DropTable("dbo.Sertifications");
            DropTable("dbo.Staffs");
        }
    }
}
