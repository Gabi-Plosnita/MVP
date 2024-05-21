using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.Windows.Controls;

namespace SupermarketApp.View
{
    public partial class SupplierEditPage : Page
    {
        public SupplierEditPage()
        {
            InitializeComponent();
            DataContext = new SupplierEditViewModel();
        }

        public SupplierEditPage(SupplierResponseDto supplier)
        {
            InitializeComponent();
            DataContext = new SupplierEditViewModel(supplier);
        }
    }
}
