namespace PMS_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db_Change : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User_Registration", "Confirm_Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User_Registration", "Confirm_Password", c => c.String(nullable: false));
        }
    }
}
