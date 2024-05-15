namespace SupermarketApp.Model.EntityLayer
{
    public class Stock
    {
        public int StockId { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public EUnitType UnitType { get; set; }

        public DateTime SupplyDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double PurchasePrice { get; set; }

        public double SalePrice { get; set; }

        public bool? IsActive { get; set; }

    }
}
