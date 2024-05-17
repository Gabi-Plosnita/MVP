using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        void AddProductReceipt(ProductReceipt productReceipt);
    }
}
