using SupermarketApp.Commands;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.Notification;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    public class CategoryViewModel : BaseNotification
    {
        private ObservableCollection<CategoryResponseDto> _categories;
        private string _newCategoryName;
        private string _updatedCategoryName;
        private CategoryResponseDto _selectedCategoryToUpdate;
        private CategoryResponseDto _selectedCategoryToDelete;

        public ObservableCollection<CategoryResponseDto> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyPropertyChanged();
            }
        }

        public string NewCategoryName
        {
            get { return _newCategoryName; }
            set
            {
                _newCategoryName = value;
                NotifyPropertyChanged();
            }
        }

        public string UpdatedCategoryName
        {
            get { return _updatedCategoryName; }
            set
            {
                _updatedCategoryName = value;
                NotifyPropertyChanged();
            }
        }

        public CategoryResponseDto SelectedCategoryToUpdate
        {
            get { return _selectedCategoryToUpdate; }
            set
            {
                _selectedCategoryToUpdate = value;
                NotifyPropertyChanged();
            }
        }

        public CategoryResponseDto SelectedCategoryToDelete
        {
            get { return _selectedCategoryToDelete; }
            set
            {
                _selectedCategoryToDelete = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand AddCategoryCommand { get; }
        public ICommand UpdateCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }

        private readonly ICategoryService _categoryService;

        public CategoryViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Categories = new ObservableCollection<CategoryResponseDto>(_categoryService.GetCategories());

            AddCategoryCommand = new RelayCommand<object>(AddCategory);
            UpdateCategoryCommand = new RelayCommand<object>(UpdateCategory);
            DeleteCategoryCommand = new RelayCommand<object>(DeleteCategory);
        }

        private void AddCategory(object param)
        {
            var newCategory = new CategoryRequestDto
            {
                Name = NewCategoryName
            };
            NewCategoryName = string.Empty;

            string errorMessage = newCategory.GetValidationErrorMessage();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                _categoryService.AddCategory(newCategory);
                Categories = new ObservableCollection<CategoryResponseDto>(_categoryService.GetCategories());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateCategory(object param)
        {
            if(SelectedCategoryToUpdate == null)
            {
                MessageBox.Show("Please select a category to update.");
                UpdatedCategoryName = string.Empty;
                return;
            }

            int id = SelectedCategoryToUpdate.CategoryId;
            var updatedCategory = new CategoryRequestDto
            {
                Name = UpdatedCategoryName
            };
            UpdatedCategoryName = string.Empty;

            string errorMessage = updatedCategory.GetValidationErrorMessage();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                _categoryService.UpdateCategory(id, updatedCategory);
                Categories = new ObservableCollection<CategoryResponseDto>(_categoryService.GetCategories());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void DeleteCategory(object param)
        {
            if(SelectedCategoryToDelete == null)
            {
                MessageBox.Show("Please select a category to delete.");
                return;
            }

            int id = SelectedCategoryToDelete.CategoryId;
            try
            {
                _categoryService.DeleteCategory(id);
                Categories = new ObservableCollection<CategoryResponseDto>(_categoryService.GetCategories());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
