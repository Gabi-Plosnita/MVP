using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Mappers
{
    public static class StockMapper
    {
        public static StockResponseDto MapToStockResponseDto(this Stock stock)
        {
            return new StockResponseDto
            {
                StockId = stock.StockId,
                ProductName = stock.Product.Name,
                Quantity = stock.Quantity,
                UnitType = stock.UnitType,
                SupplyDate = stock.SupplyDate,
                ExpirationDate = stock.ExpirationDate,
                PurchasePrice = stock.PurchasePrice,
                SalePrice = stock.SalePrice
            };
        }

        public static List<StockResponseDto> MapToListOfStockResponseDto(this List<Stock> stocks)
        {
            return stocks.Select(stock => stock.MapToStockResponseDto()).ToList();
        }

        public static Stock MapToStock(this StockRequestDto stockRequestDto)
        {
            return new Stock
            {
                ProductId = stockRequestDto.ProductId,
                Quantity = stockRequestDto.Quantity,
                UnitType = stockRequestDto.UnitType,
                SupplyDate = stockRequestDto.SupplyDate,
                ExpirationDate = stockRequestDto.ExpirationDate,
                PurchasePrice = stockRequestDto.PurchasePrice
            };
        }
    }
}
