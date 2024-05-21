using SupermarketApp.Commands;
using SupermarketApp.Model.BusinessLogicLayer.Mappers;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    public class CategoryViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService = new CategoryService();
        private bool _isEditMode;
        public CategoryResponseDto EditingCategory { get; set; }
        public string NewName { get; set; } = "";

        public ICommand SaveCategoryCommand { get; set; }

        public CategoryViewModel()
        {
            SaveCategoryCommand = new RelayCommand<object>(SaveCategory);
            _isEditMode = false;
        }
        public CategoryViewModel(CategoryResponseDto category) : this()
        {
            NewName = category.Name;
            _isEditMode = true;
            EditingCategory = category;
        }

        public void SaveCategory(object? obj)
        {
            if(_isEditMode)
            {
                int id = EditingCategory.CategoryId;
                EditingCategory.Name = NewName;
                CategoryRequestDto categoryRequestDto = EditingCategory.MapToCategoryRequestDto();
                try
                {
                    _categoryService.UpdateCategory(id, categoryRequestDto);

                    var currentPage = obj as Page;
                    var adminPage = new AdminPage();
                    currentPage?.NavigationService?.Navigate(adminPage);
                    MessageBox.Show("Category updated successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                CategoryRequestDto newCategory = new CategoryRequestDto()
                {
                    Name = NewName
                };
                try
                {
                    _categoryService.AddCategory(newCategory);

                    var currentPage = obj as Page;
                    var adminPage = new AdminPage();
                    currentPage?.NavigationService?.Navigate(adminPage);
                    MessageBox.Show("Category added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
