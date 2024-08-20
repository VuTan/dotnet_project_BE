using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Img> Img { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(c => c.Id);
                e.Property(c => c.Name).IsRequired().HasMaxLength(100);

                e.HasMany(c => c.SubCategories)
                .WithOne(sc => sc.Category)
                .HasForeignKey(sc => sc.IdCategory)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SubCategory>(e =>
            {
                e.ToTable("SubCategory");
                e.HasKey(sc => sc.Id);
                e.Property(sc => sc.Name).IsRequired().HasMaxLength(100);
                e.Property(sc => sc.IdCategory).IsRequired();

                e.HasMany(sc => sc.Products)
                .WithOne(p => p.SubCategory)
                .HasForeignKey(p => p.IdSubCategory)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(1000);
                entity.Property(p => p.Price).IsRequired();

                entity.HasMany(p => p.Imgs)
                      .WithOne(i => i.Product)
                      .HasForeignKey(i => i.IdProduct)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(p => p.Sizes)
                 .WithMany(ps => ps.Products)
                 .UsingEntity<Dictionary<string, object>>(
                     "ProductSize", 
                     j => j.HasOne<Size>().WithMany().HasForeignKey("ProductSizeId"),
                     j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                     j =>
                     {
                         j.HasKey("ProductId", "ProductSizeId"); 
                         j.ToTable("ProductSize"); 
                     }
                 );

                entity.HasMany(p => p.ProductToppings)
                .WithOne(pt => pt.Product)
                .HasForeignKey(pt => pt.ProductId);

            });

            modelBuilder.Entity<Img>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.SourceImg).IsRequired().HasMaxLength(1000);
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(ps => ps.Id);
                entity.Property(ps => ps.Name).IsRequired().HasMaxLength(50);
                entity.Property(ps => ps.Price).IsRequired();
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Price).HasDefaultValue(0);
            });

            modelBuilder.Entity<ProductTopping>(entity =>
            {
                entity.HasKey(pt => new { pt.ProductId, pt.ToppingId });

                entity.HasOne(pt => pt.Product)
                      .WithMany(p => p.ProductToppings)
                      .HasForeignKey(pt => pt.ProductId);

                entity.HasOne(pt => pt.Topping)
                      .WithMany(t => t.ProductToppings)
                      .HasForeignKey(pt => pt.ToppingId);
            });

        }

    }
}
