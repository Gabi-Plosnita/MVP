using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public interface IProductService
    {
        List<ProductResponseDto> GetAllProducts();

        ProductResponseDto GetProductById(int id);

        ProductResponseDto GetProductByName(string name);

        ProductResponseDto GetProductByBarcode(string barcode);

        void AddProduct(ProductRequestDto productDto);

        void UpdateProduct(int id, ProductRequestDto updatedProductDto);

        void DeleteProduct(int id);
    }
}
