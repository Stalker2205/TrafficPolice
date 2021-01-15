namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatDriverPassport : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Passports");
            AlterColumn("dbo.Passports", "PassportID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Passports", "PassportID");
            CreateIndex("dbo.Passports", "PassportID");
            AddForeignKey("dbo.Passports", "PassportID", "dbo.Drivers", "DriverID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passports", "PassportID", "dbo.Drivers");
            DropIndex("dbo.Passports", new[] { "PassportID" });
            DropPrimaryKey("dbo.Passports");
            AlterColumn("dbo.Passports", "PassportID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Passports", "PassportID");
        }
    }
}
