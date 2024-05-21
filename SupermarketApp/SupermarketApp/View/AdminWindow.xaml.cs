using SupermarketApp.StartupHelper;
using SupermarketApp.ViewModel;
using System.Windows;


namespace SupermarketApp.View
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            
            InitializeComponent();
            DataContext = new AdminViewModel();
        }
    }
}
