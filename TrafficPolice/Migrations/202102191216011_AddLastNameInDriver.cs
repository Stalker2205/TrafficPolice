namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastNameInDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "LastName");
        }
    }
}
