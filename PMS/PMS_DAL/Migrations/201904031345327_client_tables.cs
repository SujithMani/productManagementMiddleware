namespace PMS_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class client_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product_Check_Out",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Offers = c.String(),
                        Discount = c.String(),
                        Shipping_Charges = c.String(),
                        TotalCharges = c.String(),
                        DestPoint = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products_Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Name = c.String(),
                        Product_Amount = c.String(),
                        UserId = c.Int(),
                        Added_Cart_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User_Registration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        User_Name = c.String(),
                        User_Email_Id = c.String(),
                        User_Address = c.String(),
                        Phone_Number = c.String(),
                        User_Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users_Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Name = c.String(),
                        Product_Price = c.String(),
                        Product_Purchase_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users_Invoice");
            DropTable("dbo.User_Registration");
            DropTable("dbo.Products_Cart");
            DropTable("dbo.Product_Check_Out");
        }
    }
}
