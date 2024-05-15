using Microsoft.EntityFrameworkCore;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.DataContext
{
    public class SupermarketDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ProductReceipt> ProductReceipts { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product Configuration // 
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
               .HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
               .HasOne(p => p.Supplier)
               .WithMany(s => s.Products)
               .HasForeignKey(p => p.SupplierId);

            modelBuilder.Entity<Product>()
               .Property(p => p.IsActive)
               .HasDefaultValue(true);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => p.IsActive == true);

            // Supplier Configuration //
            modelBuilder.Entity<Supplier>()
                .HasKey(s => s.SupplierId);

            modelBuilder.Entity<Supplier>()
                .Property(s => s.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Supplier>()
                .HasQueryFilter(s => s.IsActive == true);

            // Category Configuration //
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(c => c.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Category>()
                .HasQueryFilter(c => c.IsActive == true);

            // Stock Configuration //
            modelBuilder.Entity<Stock>()
                .HasKey(s => s.StockId);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Stock>()
                .Property(s => s.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Stock>()
                .HasQueryFilter(s => s.IsActive == true);

            // User Configuration //
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<User>()
                .HasQueryFilter(u => u.IsActive == true);

            // ProductReceipt Configuration //
            modelBuilder.Entity<ProductReceipt>()
                .HasKey(pr => new { pr.ReceiptId, pr.ProductId });

            modelBuilder.Entity<ProductReceipt>()
                .HasOne(pr => pr.Product)
                .WithMany()
                .HasForeignKey(pr => pr.ProductId);

            modelBuilder.Entity<ProductReceipt>()
                .Property(pr => pr.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<ProductReceipt>()
                .HasQueryFilter(pr => pr.IsActive == true);

            // Receipt Configuration //
            modelBuilder.Entity<Receipt>()
                .HasKey(r => r.ReceiptId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Cashier)
                .WithMany(c => c.Receipts)
                .HasForeignKey(r => r.CashierId);

            modelBuilder.Entity<Receipt>()
                .HasMany(r => r.ProductReceipts)
                .WithOne()
                .HasForeignKey(pr => pr.ReceiptId);

            modelBuilder.Entity<Receipt>()
                .Property(r => r.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Receipt>()
                .HasQueryFilter(r => r.IsActive == true);

            // Offer Configuration //
            modelBuilder.Entity<Offer>()
                .HasKey(o => o.OfferId);

            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Product)
                .WithMany()
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<Offer>()
                .Property(o => o.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Offer>()
                .HasQueryFilter(o => o.IsActive == true);

        }

    }
}
