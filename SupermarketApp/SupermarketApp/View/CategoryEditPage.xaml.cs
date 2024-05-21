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
            DataContext = new CategoryViewModel();
        }

        public CategoryEditPage(CategoryResponseDto category)
        {
            InitializeComponent();
            DataContext = new CategoryViewModel(category);
        }
    }
}
