namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface IProductReceiptRepository
    {

        void AddProductReceipt(int receiptId, int productId, int quantity);
        
    }
}
