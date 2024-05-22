using SupermarketApp.Commands;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    public class SupplierEditViewModel : BaseViewModel
    {
        private readonly ISupplierService _supplierService = new SupplierService();
        private bool _isEditMode;
        public SupplierResponseDto EditingSupplier { get; set; }

        public string Name { get; set; } = "";
        public string Country { get; set; } = "";
        public ICommand SaveSupplierCommand { get; set; }

        public string PageTitle
        {
            get
            {
                if (_isEditMode)
                {
                    return "Edit Supplier";
                }
                else
                {
                    return "Add Supplier";
                }
            }
        }
        public SupplierEditViewModel()
        {
            _isEditMode = false;
            SaveSupplierCommand = new RelayCommand<object>(SaveSupplier);
        }
        public SupplierEditViewModel(SupplierResponseDto supplier) : this()
        {
            Name = supplier.Name;
            Country = supplier.Country;
            _isEditMode = true;
            EditingSupplier = supplier;
        }
        public void SaveSupplier(object? obj)
        {
            var supplierRequestDto = new SupplierRequestDto()
            {
                Name = Name,
                Country = Country
            };
            string validationMessage = supplierRequestDto.GetValidationErrorMessage();
            if (!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            if(_isEditMode)
            {
                try
                {
                    int id = EditingSupplier.SupplierId;
                    _supplierService.UpdateSupplier(id, supplierRequestDto);
                    MessageBox.Show("Supplier updated successfully");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    _supplierService.AddSupplier(supplierRequestDto);
                    MessageBox.Show("Supplier added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            var currentPage = obj as Page;
            var adminPage = new AdminPage();
            currentPage?.NavigationService?.Navigate(adminPage);
        }
    }
}
