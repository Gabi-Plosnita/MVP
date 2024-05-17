using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public class ProductReceiptRepository : BaseRepository, IProductReceiptRepository
    {
        public ProductReceiptRepository(SupermarketDbContext context) : base(context)
        {
        }

        public void AddProductReceipt(ProductReceipt productReceipt)
        {
            var receipt = _context.Receipts.Find(productReceipt.ReceiptId);

            if(receipt == null)
            {
                throw new Exception($"Receipt with id {productReceipt.ReceiptId} not found");
            }

            if(receipt.IsPaid)
            {
                throw new Exception($"Can't modify receipt with id {productReceipt.ReceiptId}");
            }

            var product = _context.Products.Find(productReceipt.ProductId);
            if(product == null)
            {
                throw new Exception($"Product with id {productReceipt.ProductId} not found");
            }

            if(productReceipt.Quantity <= 0)
            {
                throw new Exception("Quantity must be greater than 0");
            }

            var stock =_context.Stocks.Where(s => s.ProductId == productReceipt.ProductId)
                                      .OrderBy(s => s.SupplyDate)
                                      .FirstOrDefault();

            if(stock == null)
            {
                throw new Exception($"Product with id {productReceipt.ProductId} is out of stock");
            }

            if(stock.ExpirationDate < DateTime.Now)
            {
                throw new Exception($"Product with id {productReceipt.ProductId} is expired");
            }

            if(stock.Quantity < productReceipt.Quantity)
            {
                throw new Exception
                    ($"There are only {stock.Quantity} products in the current stock. You can't buy {productReceipt.Quantity} products");
            }

            stock.Quantity -= productReceipt.Quantity;
            if(stock.Quantity == 0)
            {
                stock.IsActive = false;
            }

            productReceipt.UnitType = stock.UnitType;
            productReceipt.Subtotal = productReceipt.Quantity * stock.SalePrice;

            _context.ProductReceipts.Add(productReceipt);
            _context.SaveChanges();
        }
    }
}
