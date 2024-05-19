using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponseDto MapToProductResponseDto(this Product product)
        {
            return new ProductResponseDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Barcode = product.Barcode,
                CategoryName = product.Category.Name,
                SupplierName = product.Supplier.Name
            };
        }

        public static List<ProductResponseDto> MapToListOfProductResponseDto(this List<Product> products)
        {
            return products.Select(product => product.MapToProductResponseDto()).ToList();
        }

        public static Product MapToProduct(this ProductRequestDto productRequestDto)
        {
            return new Product
            {
                Name = productRequestDto.Name,
                Barcode = productRequestDto.Barcode,
                CategoryId = productRequestDto.CategoryId,
                SupplierId = productRequestDto.SupplierId
            };
        }

    }
}
