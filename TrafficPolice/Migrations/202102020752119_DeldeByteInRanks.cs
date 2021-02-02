namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeldeByteInRanks : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ranks", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ranks", "Photo", c => c.Binary());
        }
    }
}
