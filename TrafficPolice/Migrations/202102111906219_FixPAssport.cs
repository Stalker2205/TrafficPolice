namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPAssport : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Passports", new[] { "PassportID" });
            DropPrimaryKey("dbo.Passports");
            AlterColumn("dbo.Passports", "PassportID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Passports", "PassportID");
            CreateIndex("dbo.Passports", "PassportID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Passports", new[] { "PassportID" });
            DropPrimaryKey("dbo.Passports");
            AlterColumn("dbo.Passports", "PassportID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Passports", "PassportID");
            CreateIndex("dbo.Passports", "PassportID");
        }
    }
}
