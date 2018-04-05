using System.Data.Entity;
using Syntra.VDOAP.CProef.Ecommerce.LIB.Entities;

namespace Syntra.VDOAP.CProef.Ecommerce.LIB.DATA
{
    class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Localize_ProductCategory> localize_ProductCategories { get; set; }
        public DbSet<Localize_Product> localize_Products { get; set; }
        public DbSet<Language>languages { get; set; }


        private static AppDBContext _instance;

        public AppDBContext() : base(@"Data Source=DESKTOP-5UDQTSH\SQLEXPRESS;Initial Catalog=ECommerce;Persist Security Info=True;User ID=GertjanVerhelst;Password=Gertjan01")
        {

        }

        private AppDBContext(string conn) : base(conn) { }



        public static AppDBContext Instance(string conn = null)
        {
            if (_instance == null)
            {
                if (!string.IsNullOrWhiteSpace(conn))
                {
                    _instance = new AppDBContext(conn);
                }
            }
            return _instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Localize_ProductCategory>()
                .HasKey(lpc => new { lpc.Category_ID, lpc.Language_ID });

            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Localize_ProductCategories)
                .WithRequired()
                .HasForeignKey(lpc => lpc.Category_ID);

            modelBuilder.Entity<Language>()
               .HasMany(l => l.Localize_ProductCategories)
               .WithRequired()
               .HasForeignKey(lpc => lpc.Language_ID);
            //

            modelBuilder.Entity<Localize_Product>()
               .HasKey(lp => new { lp.Product_ID, lp.Language_ID });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Localize_Product)
                .WithRequired()
                .HasForeignKey(lp => lp.Product_ID);

            modelBuilder.Entity<Language>()
               .HasMany(l => l.Localize_Product)
               .WithRequired()
               .HasForeignKey(lp => lp.Language_ID);

        }

       
    }
}
