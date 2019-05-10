namespace PMS_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products_Cart", "In_Cart_Status", c => c.String());
            AlterColumn("dbo.User_Registration", "User_Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User_Registration", "User_Name", c => c.String());
            DropColumn("dbo.Products_Cart", "In_Cart_Status");
        }
    }
}
