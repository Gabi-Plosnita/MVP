using SupermarketApp.Commands;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    public class CategoryEditViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService = new CategoryService();
        private bool _isEditMode;
        public CategoryResponseDto EditingCategory { get; set; }
        public string NewName { get; set; } = "";
        public string PageTitle
        {
            get
            {
                if (_isEditMode)
                {
                    return "Edit Category";
                }
                else
                {
                    return "Add Category";
                }
            }
        }

        public ICommand SaveCategoryCommand { get; set; }

        public CategoryEditViewModel()
        {
            SaveCategoryCommand = new RelayCommand<object>(SaveCategory);
            _isEditMode = false;
        }
        public CategoryEditViewModel(CategoryResponseDto category) : this()
        {
            NewName = category.Name;
            _isEditMode = true;
            EditingCategory = category;
        }

        public void SaveCategory(object? obj)
        {
            var categoryRequestDto = new CategoryRequestDto()
            {
                Name = NewName
            };
            if (_isEditMode)
            {        
                try
                {
                    int id = EditingCategory.CategoryId;
                    _categoryService.UpdateCategory(id, categoryRequestDto);
                    MessageBox.Show("Category updated successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    _categoryService.AddCategory(categoryRequestDto);
                    MessageBox.Show("Category added successfully");
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
