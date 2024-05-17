using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface IProductRepository
    {
       
        List<Product> GetAllProducts();

        Product GetProductById(int id);

        Product GetProductByName(string name);

        Product GetProductByBarcode(string barcode);

        void AddProduct(Product product);

        void UpdateProduct(int id, Product updatedProduct);

        void DeleteProduct(int id);
    }
}
