namespace PMS_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db_Change3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_Registration", "Date_Of_Birth", c => c.DateTime(nullable: false));
            DropColumn("dbo.User_Registration", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User_Registration", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.User_Registration", "Date_Of_Birth");
        }
    }
}
