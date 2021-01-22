namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedocument2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "CtcID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "CtcID");
        }
    }
}
