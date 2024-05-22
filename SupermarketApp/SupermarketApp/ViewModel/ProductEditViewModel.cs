using SupermarketApp.Commands;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    public class ProductEditViewModel : BaseViewModel
    {
        private readonly IProductService _productService = new ProductService();
        private readonly ICategoryService _categoryService = new CategoryService();
        private readonly ISupplierService _supplierService = new SupplierService();

        private bool _isEditMode;
        public ProductResponseDto EditingProduct { get; set; }
        public string Name { get; set; } = "";
        public string Barcode { get; set; } = "";
        public ObservableCollection<CategoryResponseDto> Categories { get; set; }
        public CategoryResponseDto SelectedCategory { get; set; }
        public ObservableCollection<SupplierResponseDto> Suppliers { get; set; }
        public SupplierResponseDto SelectedSupplier { get; set; }

        public ICommand SaveProductCommand { get; set; }

        public string PageTitle
        {
            get
            {
                if (_isEditMode)
                {
                    return "Edit Product";
                }
                else
                {
                    return "Add Product";
                }
            }
        }
        public ProductEditViewModel()
        {
            Categories = new ObservableCollection<CategoryResponseDto>(_categoryService.GetCategories());
            Suppliers = new ObservableCollection<SupplierResponseDto>(_supplierService.GetSuppliers());

            SaveProductCommand = new RelayCommand<object>(SaveProduct);

            _isEditMode = false;
        }
        public ProductEditViewModel(ProductResponseDto product) : this()
        {
            Name = product.Name;
            Barcode = product.Barcode;
            SelectedCategory = Categories.FirstOrDefault(category => category.Name == product.CategoryName);
            SelectedSupplier = Suppliers.FirstOrDefault(supplier => supplier.Name == product.SupplierName);
            _isEditMode = true;
            EditingProduct = product;

        }

        private void SaveProduct(object? obj)
        {
            if(SelectedCategory == null || SelectedSupplier == null)
            {
                MessageBox.Show("Please select a category and a supplier");
                return;
            }

            var productRequestDto = new ProductRequestDto()
            {
                Name = Name,
                Barcode = Barcode,
                CategoryId = SelectedCategory.CategoryId,
                SupplierId = SelectedSupplier.SupplierId
            };
            string validationMessage = productRequestDto.GetValidationErrorMessage();
            if (!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            if (_isEditMode)
            {
                try
                {
                    int id = EditingProduct.ProductId;
                    _productService.UpdateProduct(id, productRequestDto);
                    MessageBox.Show("Product updated successfully");
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
                    _productService.AddProduct(productRequestDto);
                    MessageBox.Show("Product added successfully");
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
