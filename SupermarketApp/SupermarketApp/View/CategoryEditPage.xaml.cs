using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.Windows.Controls;

namespace SupermarketApp.View
{
    public partial class CategoryEditPage : Page
    {
        public CategoryEditPage()
        {
            InitializeComponent();
            DataContext = new CategoryEditViewModel();
        }

        public CategoryEditPage(CategoryResponseDto category)
        {
            InitializeComponent();
            DataContext = new CategoryEditViewModel(category);
        }
    }
}
