namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatStatement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statements",
                c => new
                    {
                        StatementsID = c.Int(nullable: false, identity: true),
                        Applicant = c.String(),
                        Cause = c.String(),
                        Act = c.String(),
                        Document_DocumentID = c.Int(),
                    })
                .PrimaryKey(t => t.StatementsID)
                .ForeignKey("dbo.Documents", t => t.Document_DocumentID)
                .Index(t => t.Document_DocumentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statements", "Document_DocumentID", "dbo.Documents");
            DropIndex("dbo.Statements", new[] { "Document_DocumentID" });
            DropTable("dbo.Statements");
        }
    }
}
