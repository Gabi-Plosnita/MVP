using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Mappers
{
    public static class ReceiptMapper
    {
        public static ProductReceiptResponseDto MapToProductReceiptResponseDto(this ProductReceipt productReceipt)
        {
            return new ProductReceiptResponseDto
            {
                ProductName = productReceipt.Product.Name,
                Quantity = productReceipt.Quantity,
                UnitType = productReceipt.UnitType,
                Subtotal = productReceipt.Subtotal
            };
        }

        public static List<ProductReceiptResponseDto> MapToListOfProductReceiptResponseDto(this List<ProductReceipt> productReceipts)
        {
            return productReceipts.Select(productReceipt => productReceipt.MapToProductReceiptResponseDto()).ToList();
        }

        public static ReceiptResponseDto MapToReceiptResponseDto(this Receipt receipt)
        {
            return new ReceiptResponseDto
            {
                ReceiptId = receipt.ReceiptId,
                DateOfIssue = receipt.DateOfIssue,
                CashierName = receipt.Cashier.Username,
                TotalPrice = receipt.TotalPrice,
                IsPaid = receipt.IsPaid,
                ProductReceipts = receipt.ProductReceipts.MapToListOfProductReceiptResponseDto()
            };
        }

        public static List<ReceiptResponseDto> MapToListOfReceiptResponseDto(this List<Receipt> receipts)
        {
            return receipts.Select(receipt => receipt.MapToReceiptResponseDto()).ToList();
        }

        public static ProductReceipt MapToProductReceipt(this ProductReceiptRequestDto productReceiptRequestDto)
        {
            return new ProductReceipt
            {
                ReceiptId = productReceiptRequestDto.ReceiptId,
                ProductId = productReceiptRequestDto.ProductId,
                Quantity = productReceiptRequestDto.Quantity,
                UnitType = productReceiptRequestDto.UnitType
            };
        }
    }
}
