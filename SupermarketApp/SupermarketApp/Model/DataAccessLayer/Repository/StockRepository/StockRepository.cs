using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public class StockRepository : BaseRepository, IStockRepository
    {
        public StockRepository(SupermarketDbContext context) : base(context)
        {
        }

        public List<Stock> GetStocks()
        {
            return _context.Stocks.ToList();
        }

        public Stock GetStock(int id)
        {
            var stock = _context.Stocks.Find(id);
            if(stock == null)
            {
                throw new Exception($"Stock with id {id} not found");
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
