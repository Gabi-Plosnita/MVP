using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.Windows.Controls;

namespace SupermarketApp.View
{
    public partial class ProductEditPage : Page
    {
        public ProductEditPage()
        {
            InitializeComponent();
            DataContext = new ProductEditViewModel();
        }

        public ProductEditPage(ProductResponseDto product)
        {
            InitializeComponent();
            DataContext = new ProductEditViewModel(product);
        }
    }
}
