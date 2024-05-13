﻿namespace SupermarketApp.Model.EntityLayer.Receipt
{
    public class ProductReceipt
    {
        public int ReceiptId { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public EMesureUnit MesureUnit { get; set; }

        public double Subtotal { get; set; }

        public bool IsActive { get; set; }
    }
}
