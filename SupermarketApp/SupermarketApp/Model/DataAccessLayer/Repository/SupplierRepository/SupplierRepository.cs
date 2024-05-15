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
            return _context.Suppliers.ToList();
        }

        public Supplier GetSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with id {id} not found");
            }

            return supplier;
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void UpdateSupplier(int id, Supplier updatedSupplier)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with id {id} not found");
            }

            _context.Entry(supplier).CurrentValues.SetValues(updatedSupplier);
            supplier.SupplierId = id;

            _context.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with id {id} not found");
            }

            supplier.IsActive = false;
            _context.SaveChanges();
        }  

        public List<Product> GetProductsFromSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with id {id} not found");
            }

            return supplier.Products;
        }
    }
}
