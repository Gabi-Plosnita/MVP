namespace SupermarketApp.Model.Entities
{
    public class Stock
    {
        public int StockId { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        // unitate de masura

        DateOnly SupplyDate { get; set; }

        DateOnly ExpirationDate { get; set; }

        public double PurchasePrice { get; set; }

        public double SalePrice { get; set; }
  
    }
}
