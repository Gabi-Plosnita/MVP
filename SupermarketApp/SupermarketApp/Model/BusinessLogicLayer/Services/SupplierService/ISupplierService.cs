using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public interface ISupplierService
    {
        List<SupplierResponseDto> GetSuppliers();

        SupplierResponseDto GetSupplier(int id);

        void AddSupplier(SupplierRequestDto supplierDto);

        void UpdateSupplier(int id, SupplierRequestDto updatedSupplierDto);

        void DeleteSupplier(int id);

        List<ProductResponseDto> GetProductsFromSupplier(int id);
    }
}
