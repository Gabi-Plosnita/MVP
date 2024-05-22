using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.Windows.Controls;

namespace SupermarketApp.View
{
    public partial class CashierPage : Page
    {
        public CashierPage(UserResponseDto user)
        {
            InitializeComponent();
            DataContext = new CashierViewModel(user);
        }
    }
}
