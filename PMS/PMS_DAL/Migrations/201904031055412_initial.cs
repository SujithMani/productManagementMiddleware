namespace PMS_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminUserPrivileges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminUserId = c.Int(nullable: false),
                        PrivilegeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminDetails", t => t.AdminUserId, cascadeDelete: true)
                .ForeignKey("dbo.Privileges", t => t.PrivilegeId, cascadeDelete: true)
                .Index(t => t.AdminUserId)
                .Index(t => t.PrivilegeId);
            
            CreateTable(
                "dbo.Privileges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrivilegeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolePrivileges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        PrivilegeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Privileges", t => t.PrivilegeId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.PrivilegeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminUserId = c.Int(nullable: false),
                        AdminRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.AdminRoleId, cascadeDelete: true)
                .ForeignKey("dbo.AdminDetails", t => t.AdminUserId, cascadeDelete: true)
                .Index(t => t.AdminUserId)
                .Index(t => t.AdminRoleId);
            
            CreateTable(
                "dbo.InvokerProductUpdates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminUserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminDetails", t => t.AdminUserId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.AdminUserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Sku = c.Int(nullable: false),
                        Keyword = c.String(),
                        Description = c.String(),
                        Prize = c.Int(nullable: false),
                        Image = c.String(),
                        Status = c.Int(nullable: false),
                        InvokerStatus = c.Int(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.OfferProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfferId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offers", t => t.OfferId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OfferId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DiscountAmount = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainCategoryProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PageDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageKey = c.String(),
                        PageDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MainCategoryProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.MainCategoryProducts", "CategoryId", "dbo.MainCategories");
            DropForeignKey("dbo.InvokerProductUpdates", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OfferProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OfferProducts", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.InvokerProductUpdates", "AdminUserId", "dbo.AdminDetails");
            DropForeignKey("dbo.AdminUserPrivileges", "PrivilegeId", "dbo.Privileges");
            DropForeignKey("dbo.RolePrivileges", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.AdminUserRoles", "AdminUserId", "dbo.AdminDetails");
            DropForeignKey("dbo.AdminUserRoles", "AdminRoleId", "dbo.Roles");
            DropForeignKey("dbo.RolePrivileges", "PrivilegeId", "dbo.Privileges");
            DropForeignKey("dbo.AdminUserPrivileges", "AdminUserId", "dbo.AdminDetails");
            DropIndex("dbo.MainCategoryProducts", new[] { "ProductId" });
            DropIndex("dbo.MainCategoryProducts", new[] { "CategoryId" });
            DropIndex("dbo.OfferProducts", new[] { "ProductId" });
            DropIndex("dbo.OfferProducts", new[] { "OfferId" });
            DropIndex("dbo.Products", new[] { "Product_Id" });
            DropIndex("dbo.InvokerProductUpdates", new[] { "ProductId" });
            DropIndex("dbo.InvokerProductUpdates", new[] { "AdminUserId" });
            DropIndex("dbo.AdminUserRoles", new[] { "AdminRoleId" });
            DropIndex("dbo.AdminUserRoles", new[] { "AdminUserId" });
            DropIndex("dbo.RolePrivileges", new[] { "PrivilegeId" });
            DropIndex("dbo.RolePrivileges", new[] { "RoleId" });
            DropIndex("dbo.AdminUserPrivileges", new[] { "PrivilegeId" });
            DropIndex("dbo.AdminUserPrivileges", new[] { "AdminUserId" });
            DropTable("dbo.PageDetails");
            DropTable("dbo.MainCategoryProducts");
            DropTable("dbo.MainCategories");
            DropTable("dbo.Offers");
            DropTable("dbo.OfferProducts");
            DropTable("dbo.Products");
            DropTable("dbo.InvokerProductUpdates");
            DropTable("dbo.AdminUserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.RolePrivileges");
            DropTable("dbo.Privileges");
            DropTable("dbo.AdminUserPrivileges");
            DropTable("dbo.AdminDetails");
        }
    }
}
