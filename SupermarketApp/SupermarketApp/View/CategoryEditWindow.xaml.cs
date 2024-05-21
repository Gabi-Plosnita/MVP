using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp.View
{
    public partial class CategoryEditWindow : Window
    {
        public CategoryEditWindow()
        {
            InitializeComponent();
            DataContext = new CategoryViewModel();
        }

        public CategoryEditWindow(CategoryResponseDto category)
        {
            InitializeComponent();
            DataContext = new CategoryViewModel(category);
        }
    }
}
