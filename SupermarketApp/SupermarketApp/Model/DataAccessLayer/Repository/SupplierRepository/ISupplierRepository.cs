using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface ISupplierRepository
    {
        List<Supplier> GetSuppliers();

        Supplier GetSupplier(int id);

        void AddSupplier(Supplier supplier);

        void UpdateSupplier(int id, Supplier updatedSupplier);

        void DeleteSupplier(int id);

        List<Product> GetProductsFromSupplier(int id);
    }
}
