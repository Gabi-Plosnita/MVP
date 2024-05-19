using SupermarketApp.Model.BusinessLogicLayer.Mappers;
using SupermarketApp.Model.DataAccessLayer.Repository;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public List<SupplierResponseDto> GetSuppliers()
        {
            var suppliers = _supplierRepository.GetSuppliers();
            var suppliersDto = suppliers.MapToListOfSupplierResponseDto();
            return suppliersDto;
        }
       
        public SupplierResponseDto GetSupplier(int id)
        {
            try
            {
                var supplier = _supplierRepository.GetSupplier(id);
                var supplierDto = supplier.MapToSupplierResponseDto();
                return supplierDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public void AddSupplier(SupplierRequestDto supplierDto)
        {
            try
            {
                var supplier = supplierDto.MapToSupplier();
                _supplierRepository.AddSupplier(supplier);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public void UpdateSupplier(int id, SupplierRequestDto updatedSupplierDto)
        {
            try
            {
                var supplier = updatedSupplierDto.MapToSupplier();
                _supplierRepository.UpdateSupplier(id, supplier);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public void DeleteSupplier(int id)
        {
            try
            {
                _supplierRepository.DeleteSupplier(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public List<ProductResponseDto> GetProductsFromSupplier(int id)
        {
            try
            {
                var products = _supplierRepository.GetProductsFromSupplier(id);
                var productsDto = products.MapToListOfProductResponseDto();
                return productsDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
