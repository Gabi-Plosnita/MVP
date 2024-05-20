using SupermarketApp.StartupHelper;
using SupermarketApp.ViewModel;
using System.Windows;


namespace SupermarketApp.View
{
    public partial class AdminWindow : Window
    {
        private readonly IAbstractFactory<CategoryWindow> _categoryWindowFactory;

        private readonly AdminViewModel _adminViewModel;
        public AdminWindow(IAbstractFactory<CategoryWindow> categoryWindowFactory , AdminViewModel adminViewModel)
        {
            
            InitializeComponent();
            // Configure windows // 
            _categoryWindowFactory = categoryWindowFactory;

            // Configure view model //
            _adminViewModel = adminViewModel;
            DataContext = _adminViewModel;
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            _categoryWindowFactory.Create().Show();
        }

        private void SuppliersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StocksButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReceiptsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
