namespace PMS_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_Registration", "Confirm_Password", c => c.String(nullable: false));
            AlterColumn("dbo.User_Registration", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.User_Registration", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.User_Registration", "User_Email_Id", c => c.String(nullable: false));
            AlterColumn("dbo.User_Registration", "User_Address", c => c.String(nullable: false));
            AlterColumn("dbo.User_Registration", "Phone_Number", c => c.String(nullable: false));
            AlterColumn("dbo.User_Registration", "User_Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User_Registration", "User_Password", c => c.String());
            AlterColumn("dbo.User_Registration", "Phone_Number", c => c.String());
            AlterColumn("dbo.User_Registration", "User_Address", c => c.String());
            AlterColumn("dbo.User_Registration", "User_Email_Id", c => c.String());
            AlterColumn("dbo.User_Registration", "LastName", c => c.String());
            AlterColumn("dbo.User_Registration", "FirstName", c => c.String());
            DropColumn("dbo.User_Registration", "Confirm_Password");
        }
    }
}
