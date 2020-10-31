using Microsoft.EntityFrameworkCore;
using NetCore_Mentoring.DAL.Entities;

namespace NetCore_Mentoring.DAL.EntityFramework
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
