using SupermarketApp.Model.BusinessLogicLayer.Mappers;
using SupermarketApp.Model.DataAccessLayer.Repository;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public List<ProductResponseDto> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            var productDtos = products.MapToListOfProductResponseDto();
            return productDtos;
        }

        public ProductResponseDto GetProductById(int id)
        {
            try
            {
                var product = _productRepository.GetProductById(id);
                var productDto = product.MapToProductResponseDto();
                return productDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProductResponseDto GetProductByName(string name)
        {
            try
            {
                var product = _productRepository.GetProductByName(name);
                var productDto = product.MapToProductResponseDto();
                return productDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProductResponseDto GetProductByBarcode(string barcode)
        {
            try
            {
                var product = _productRepository.GetProductByBarcode(barcode);
                var productDto = product.MapToProductResponseDto();
                return productDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddProduct(ProductRequestDto productDto)
        {
            try
            {
                var product = productDto.MapToProduct();
                _productRepository.AddProduct(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(int id, ProductRequestDto updatedProductDto)
        {
            try
            {
                var product = updatedProductDto.MapToProduct();
                _productRepository.UpdateProduct(id, product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
