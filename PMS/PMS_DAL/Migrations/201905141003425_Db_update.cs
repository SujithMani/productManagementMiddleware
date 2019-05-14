namespace PMS_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_Registration", "DateOfBirth", c => c.DateTime(nullable: false));
            DropTable("dbo.Products_Cart");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products_Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Name = c.String(),
                        Product_Amount = c.String(),
                        UserId = c.Int(),
                        Added_Cart_Date = c.DateTime(nullable: false),
                        In_Cart_Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.User_Registration", "DateOfBirth");
        }
    }
}
