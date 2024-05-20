using SupermarketApp.ViewModel;
using System.Windows;


namespace SupermarketApp.View
{
    public partial class AdminWindow : Window
    {
        private readonly AdminViewModel _adminViewModel;
        public AdminWindow(AdminViewModel adminViewModel)
        {
            InitializeComponent();
            _adminViewModel = adminViewModel;
            DataContext = _adminViewModel;
        }
    }
}
