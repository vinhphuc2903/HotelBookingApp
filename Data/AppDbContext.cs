using Microsoft.EntityFrameworkCore;
using MiniShopBE.Areas.Products.Models;

namespace MiniShopBE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapping ProductModel to table Products
            modelBuilder.Entity<ProductModel>().ToTable("Products");
        }
    }
}
