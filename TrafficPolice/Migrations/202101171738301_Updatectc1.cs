namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatectc1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ctcs", "DocumentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ctcs", "DocumentID", c => c.Int(nullable: false));
        }
    }
}
