using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface IProductReceiptRepository
    {

        void AddProductReceipt(ProductReceipt productReceipt);
        
    }
}
