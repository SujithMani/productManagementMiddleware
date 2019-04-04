namespace PMS
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using PMS.Models;

    public class Context : DbContext
    {
        // Your context has been configured to use a 'Context' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PMS_DAL_DAL.Context' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Context' 
        // connection string in the application configuration file.
        public Context()
            : base("name=Context")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<AdminDetails> AdminDetails { get; set; }
        public virtual DbSet<AdminUserPrivilege> AdminUserPrivilege { get; set; }
        public virtual DbSet<AdminUserRole> AdminUserRole { get; set; }
        public virtual DbSet<InvokerProductUpdate> InvokerProductUpdate { get; set; }
        public virtual DbSet<MainCategory> MainCategory { get; set; }
        public virtual DbSet<MainCategoryProduct> MainCategoryProduct { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<OfferProduct> OfferProduct { get; set; }
        public virtual DbSet<PageDetails> PageDetails { get; set; }
        public virtual DbSet<Privilege> Privilege { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePrivilege> RolePrivilege { get; set; }
        public virtual DbSet<User_Registration> User_Registration { get; set; }
        public virtual DbSet<Products_Cart> Products_Cart { get; set; }
        public virtual DbSet<Users_Invoice> Users_Invoice { get; set; }
        public virtual DbSet<Product_Check_Out> Product_Check_Out { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}