namespace PMS_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DATABASE_UPDATE : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Product_Id", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Product_Id" });
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Keyword", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Offers", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.MainCategories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.PageDetails", "PageKey", c => c.String(nullable: false));
            AlterColumn("dbo.PageDetails", "PageDescription", c => c.String(nullable: false));
            DropColumn("dbo.Products", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Product_Id", c => c.Int());
            AlterColumn("dbo.PageDetails", "PageDescription", c => c.String());
            AlterColumn("dbo.PageDetails", "PageKey", c => c.String());
            AlterColumn("dbo.MainCategories", "CategoryName", c => c.String());
            AlterColumn("dbo.Offers", "Description", c => c.String());
            AlterColumn("dbo.Products", "Image", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Keyword", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            CreateIndex("dbo.Products", "Product_Id");
            AddForeignKey("dbo.Products", "Product_Id", "dbo.Products", "Id");
        }
    }
}
