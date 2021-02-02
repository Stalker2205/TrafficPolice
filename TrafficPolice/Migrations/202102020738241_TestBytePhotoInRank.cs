namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestBytePhotoInRank : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ranks", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ranks", "Photo");
        }
    }
}
