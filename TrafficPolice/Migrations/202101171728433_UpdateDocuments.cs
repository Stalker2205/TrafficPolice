namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDocuments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ctcs", "DocumentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ctcs", "DocumentID");
        }
    }
}
