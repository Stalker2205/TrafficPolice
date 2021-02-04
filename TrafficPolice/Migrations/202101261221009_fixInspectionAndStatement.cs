namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixInspectionAndStatement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inspections", "Document_DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Statements", "Document_DocumentID", "dbo.Documents");
            DropIndex("dbo.Inspections", new[] { "Document_DocumentID" });
            DropIndex("dbo.Statements", new[] { "Document_DocumentID" });
            RenameColumn(table: "dbo.Inspections", name: "Document_DocumentID", newName: "DocumentID");
            RenameColumn(table: "dbo.Statements", name: "Document_DocumentID", newName: "DocumentID");
            AlterColumn("dbo.Inspections", "DocumentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Statements", "DocumentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Inspections", "DocumentID");
            CreateIndex("dbo.Statements", "DocumentID");
            AddForeignKey("dbo.Inspections", "DocumentID", "dbo.Documents", "DocumentID", cascadeDelete: true);
            AddForeignKey("dbo.Statements", "DocumentID", "dbo.Documents", "DocumentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statements", "DocumentID", "dbo.Documents");
            DropForeignKey("dbo.Inspections", "DocumentID", "dbo.Documents");
            DropIndex("dbo.Statements", new[] { "DocumentID" });
            DropIndex("dbo.Inspections", new[] { "DocumentID" });
            AlterColumn("dbo.Statements", "DocumentID", c => c.Int());
            AlterColumn("dbo.Inspections", "DocumentID", c => c.Int());
            RenameColumn(table: "dbo.Statements", name: "DocumentID", newName: "Document_DocumentID");
            RenameColumn(table: "dbo.Inspections", name: "DocumentID", newName: "Document_DocumentID");
            CreateIndex("dbo.Statements", "Document_DocumentID");
            CreateIndex("dbo.Inspections", "Document_DocumentID");
            AddForeignKey("dbo.Statements", "Document_DocumentID", "dbo.Documents", "DocumentID");
            AddForeignKey("dbo.Inspections", "Document_DocumentID", "dbo.Documents", "DocumentID");
        }
    }
}
