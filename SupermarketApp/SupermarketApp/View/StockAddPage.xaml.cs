using SupermarketApp.ViewModel;
using System.Windows.Controls;

namespace SupermarketApp.View
{
    public partial class StockAddPage : Page
    {
        public StockAddPage()
        {
            InitializeComponent();
            DataContext = new StockAddViewModel();
        }
    }
}
