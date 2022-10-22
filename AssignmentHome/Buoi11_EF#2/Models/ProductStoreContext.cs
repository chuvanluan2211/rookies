using Microsoft.EntityFrameworkCore;
using Buoi11_EF_2.Models;

namespace Buoi11_EF_2.Models
{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext(DbContextOptions<ProductStoreContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Category>()
                            .ToTable("Category")
                            .HasKey(cat => cat.CategoryId);
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .UseIdentityColumn(1)
                            .IsRequired();
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryName)
                            .HasColumnName("CategoryName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500)
                            .IsRequired();

            modelBuilder.Entity<Product>()
                            .ToTable("Product")
                            .HasKey(p => p.ProductId);
            // modelBuilder.Entity<Product>()
            //                 .HasOne<Category>(p => p.Category)
            //                 .WithMany(p => p.Products)
            //                 .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>()
                            .Property(p => p.ProductId)
                            .HasColumnName("ProductId")
                            .HasColumnType("int")
                            .UseIdentityColumn(1)
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(p => p.ProductName)
                            .HasColumnName("ProductName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(100)
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(p => p.Manufature)
                            .HasColumnName("Manufacture")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);
                            //.IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(p => p.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .IsRequired();

            modelBuilder.Entity<Category>()
                            .HasData(new Category 
                            {
                                CategoryId = 1,
                                CategoryName = "computer"
                            });
            modelBuilder.Entity<Product>()
                            .HasData(new Product 
                            {
                                ProductId = 1,
                                ProductName = "computer",
                                CategoryId = 1,
                                Manufature = "steel"
                            });                    
                                
        }
        public DbSet<Product> Products {get; set;} = null!;
        public DbSet<Category> Categories {get; set;} = null!;

    }
}