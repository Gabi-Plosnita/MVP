using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface IReceiptRepository
    {
        int AddReceipt(Receipt receipt);

        void AddProductReceipt(ProductReceipt productReceipt);

        void PayReceipt(int receiptId);

        List<Receipt> GetReceipts();

        Receipt GetReceipt(int receiptId);
    }
}
