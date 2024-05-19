namespace SupermarketApp.Model.EntityLayer
{
    public class StockResponseDto
    {
        public int StockId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public EUnitType UnitType { get; set; }

        public DateTime SupplyDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double PurchasePrice { get; set; }

        public double SalePrice { get; set; }

    }
}
