using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public interface IStockService
    {
        List<StockResponseDto> GetStocks();

        StockResponseDto GetStock(int id);

        void AddStock(StockRequestDto stockDto);

        void DeleteStock(int id);

        List<ProductResponseDto> GetProducts(DateTime expirationDate);
    }
}
