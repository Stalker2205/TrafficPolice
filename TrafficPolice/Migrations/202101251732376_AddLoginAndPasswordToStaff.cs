namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoginAndPasswordToStaff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "Login", c => c.String());
            AddColumn("dbo.Staffs", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "Password");
            DropColumn("dbo.Staffs", "Login");
        }
    }
}
