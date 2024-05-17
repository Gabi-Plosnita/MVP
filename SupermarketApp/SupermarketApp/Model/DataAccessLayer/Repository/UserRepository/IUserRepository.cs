using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        void AddReceipt(Receipt receipt);

        void AddProductReceipt(ProductReceipt productReceipt);
    }
}
