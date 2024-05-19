using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Mappers
{
    public static class SupplierMapper
    {
        public static SupplierResponseDto MapToSupplierResponseDto(this Supplier supplier)
        {
            return new SupplierResponseDto
            {
                SupplierId = supplier.SupplierId,
                Name = supplier.Name,
                Country = supplier.Country,
            };
        }

        public static List<SupplierResponseDto> MapToListOfSupplierResponseDto(this List<Supplier> suppliers)
        {
            return suppliers.Select(supplier => supplier.MapToSupplierResponseDto()).ToList();
        }

        public static Supplier MapToSupplier(this SupplierRequestDto supplierDto)
        {
            return new Supplier
            {
                Name = supplierDto.Name,
                Country = supplierDto.Country
            };
        }

    }
}
