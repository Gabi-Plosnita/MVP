﻿namespace SupermarketApp.Model.EntityLayer.Receipt
{
    public class Receipt
    {
        public int ReceiptId { get; set; }

        public DateOnly DateOfIssue { get; set; }

        public int CashierId { get; set; }

        public virtual User Cashier { get; set; }

        public virtual List<ProductReceipt> ProductReceipts { get; set; }

        public double TotalPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
