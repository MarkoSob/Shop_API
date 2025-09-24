using Microsoft.EntityFrameworkCore;
using Shop_DAL.Models;

namespace Shop_DAL
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth)
                    .IsRequired();

                entity.Property(e => e.RegistrationDate)
                    .IsRequired();

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ArticleNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(e => e.ArticleNumber).IsUnique();

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(e => e.Number).IsUnique();

                entity.Property(e => e.OrderDate)
                    .IsRequired();

                entity.Property(e => e.TotalAmount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CustomerId)
                    .IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OrderId).IsRequired();
                entity.Property(e => e.ProductId).IsRequired();

                entity.Property(e => e.Quantity).IsRequired();

                entity.Property(e => e.UnitPrice)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId);
            });

            DataSeeder.SeedData(modelBuilder);
        }
    }
}
