using SupermarketApp.Model.BusinessLogicLayer.Mappers;
using SupermarketApp.Model.DataAccessLayer.Repository;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService()
        {
            _stockRepository = new StockRepository();
        }

        public List<StockResponseDto> GetStocks()
        {
            var stocks = _stockRepository.GetStocks();
            var stockDtos = stocks.MapToListOfStockResponseDto();
            return stockDtos;
        }

        public StockResponseDto GetStock(int id)
        {
            try
            {
                var stock = _stockRepository.GetStock(id);
                var stockDto = stock.MapToStockResponseDto();
                return stockDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddStock(StockRequestDto stockDto)
        {
            try
            {
                var stock = stockDto.MapToStock();
                _stockRepository.AddStock(stock);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteStock(int id)
        {
            try
            {
                _stockRepository.DeleteStock(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProductResponseDto> GetProducts(DateTime expirationDate)
        {
            var products = _stockRepository.GetProducts(expirationDate);
            var productDtos = products.MapToListOfProductResponseDto();
            return productDtos;
        }
    }
}
