using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface IStockRepository
    {
        List<Stock> GetStocks();

        Stock GetStock(int id);

        void AddStock(Stock stock);

        void DeleteStock(int id);

        List<Product> GetProducts(DateTime expirationDate);

    }
}
