using Microsoft.EntityFrameworkCore;
using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public class StockRepository : BaseRepository, IStockRepository
    {
        private double CommercialMargin = 0.1;
        public StockRepository(SupermarketDbContext context) : base(context)
        {
        }

        public List<Stock> GetStocks()
        {
            var stocks = _context.Stocks
                                 .Include(s => s.Product)
                                 .ToList();
            foreach(var stock in stocks)
            {
                if(stock.ExpirationDate < DateTime.Now)
                {
                    stock.IsActive = false;
                }
            }
            _context.SaveChanges();
            return _context.Stocks.ToList();
        }

        public Stock GetStock(int id)
        {
            var stock = _context.Stocks
                                .Include(s => s.Product)
                                .FirstOrDefault(s => s.StockId == id);
            if(stock == null)
            {
                throw new Exception($"Stock with id {id} not found");
            }

            if(stock.ExpirationDate < DateTime.Now)
            {
                stock.IsActive = false;
                _context.SaveChanges();
            }

            return stock;
        }

        public void AddStock(Stock stock)
        {
            var product = _context.Products.Find(stock.ProductId);
            if(product == null)
            {
                throw new Exception($"Product with id {stock.ProductId} not found");
            }

            if(stock.Quantity <= 0)
            {
                throw new Exception("Quantity must be greater than 0");
            }

            if(stock.PurchasePrice <= 0)
            {
                throw new Exception("Purchase price must be greater than 0");
            }

            if(stock.SupplyDate >= stock.ExpirationDate)
            {
                throw new Exception("Supply date must be before expiration date");
            }

            stock.SalePrice = stock.PurchasePrice + stock.PurchasePrice * CommercialMargin;

            _context.Stocks.Add(stock);
            _context.SaveChanges();
        }

        public List<Product> GetProducts(DateTime expirationDate)
        {
            var products = _context.Stocks
                .Where(s => s.ExpirationDate == expirationDate)
                .Select(s => s.Product)
                .ToList();

            return products;
        }

    }
}
