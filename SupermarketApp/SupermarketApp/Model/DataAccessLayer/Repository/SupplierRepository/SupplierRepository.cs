using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        public SupplierRepository(SupermarketDbContext context) : base(context)
        {
        }

        public List<Supplier> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public Supplier GetSupplier(int id)
        {
            throw new NotImplementedException();
        }

        public void AddSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public void UpdateSupplier(int id, Supplier updatedSupplier)
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplier(int id)
        {
            throw new NotImplementedException();
        }  

        public List<Product> GetProductsFromSupplier(int id)
        {
            throw new NotImplementedException();
        }
    }
}
