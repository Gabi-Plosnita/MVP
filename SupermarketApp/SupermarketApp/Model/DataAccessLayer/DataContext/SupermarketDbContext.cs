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
               .WithMany()
               .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
               .HasOne(p => p.Supplier)
               .WithMany()
               .HasForeignKey(p => p.SupplierId);

            // Supplier Configuration //
            modelBuilder.Entity<Supplier>()
                .HasKey(s => s.SupplierId);

            // Category Configuration //
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            // Stock Configuration //
            modelBuilder.Entity<Stock>()
                .HasKey(s => s.StockId);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductId);

            // User Configuration //
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            // ProductReceipt Configuration //
            modelBuilder.Entity<ProductReceipt>()
                .HasKey(pr => new { pr.ReceiptId, pr.ProductId });

            modelBuilder.Entity<ProductReceipt>()
                .HasOne(pr => pr.Product)
                .WithMany()
                .HasForeignKey(pr => pr.ProductId);

            // Receipt Configuration //
            modelBuilder.Entity<Receipt>()
                .HasKey(r => r.ReceiptId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Cashier)
                .WithMany()
                .HasForeignKey(r => r.CashierId);

            modelBuilder.Entity<Receipt>()
                .HasMany(r => r.ProductReceipts)
                .WithOne()
                .HasForeignKey(pr => pr.ReceiptId);

            // Offer Configuration //
            modelBuilder.Entity<Offer>()
                .HasKey(o => o.OfferId);

            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Product)
                .WithMany()
                .HasForeignKey(o => o.ProductId);

        }

    }
}
