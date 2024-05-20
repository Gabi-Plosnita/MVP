using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public interface IReceiptService
    {
        int AddReceipt(int cashierId);

        void AddProductReceipt(ProductReceiptRequestDto productReceiptDto);

        void PayReceipt(int receiptId);

        List<ReceiptResponseDto> GetReceipts();

        ReceiptResponseDto GetReceipt(int receiptId);
    }
}
