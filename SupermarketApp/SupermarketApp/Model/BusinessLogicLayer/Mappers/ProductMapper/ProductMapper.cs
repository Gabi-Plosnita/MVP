using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponseDto MapToProductResponseDto(this Product product)
        {
            var productResponseDto = new ProductResponseDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Barcode = product.Barcode,
                CategoryName = product.Category.Name,
                SupplierName = product.Supplier.Name
            };

            return productResponseDto;
        }

        public static List<ProductResponseDto> MapToListOfProductResponseDto(this List<Product> products)
        {
            return products.Select(product => MapToProductResponseDto(product)).ToList();
        }

    }
}
