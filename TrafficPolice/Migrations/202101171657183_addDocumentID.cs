namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDocumentID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "DocumentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "DocumentID");
        }
    }
}
