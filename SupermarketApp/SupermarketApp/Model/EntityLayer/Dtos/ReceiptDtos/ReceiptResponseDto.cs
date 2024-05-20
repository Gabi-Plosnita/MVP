namespace SupermarketApp.Model.EntityLayer
{
    public class ReceiptResponseDto
    {
        public int ReceiptId { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string CashierName { get; set; }

        public List<ProductReceiptResponseDto> ProductReceipts { get; set; }

        public double TotalPrice { get; set; }

        public bool IsPaid { get; set; }

    }
}
