using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface IProductRepository
    {
       
        List<Product> GetAllProducts();

        List<Product> GetProductsByExpirationDate(DateTime expirationDate);

        Product GetProductById(int id);

        Product GetProductByName(string name);

        Product GetProductByBarcode(string barcode);

        void AddProduct(Product product);

        void UpdateProduct(int id, Product product);

        void DeleteProduct(int id);
    }
}
