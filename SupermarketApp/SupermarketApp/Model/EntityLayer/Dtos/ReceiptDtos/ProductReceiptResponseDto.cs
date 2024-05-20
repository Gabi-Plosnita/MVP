namespace SupermarketApp.Model.EntityLayer
{
    public class ProductReceiptResponseDto
    {
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public EUnitType UnitType { get; set; }

        public double Subtotal { get; set; }

    }
}
