namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelitePositionTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Positions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        PositionName = c.String(),
                    })
                .PrimaryKey(t => t.PositionID);
            
        }
    }
}
