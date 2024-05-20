using SupermarketApp.Model.DataAccessLayer.Repository;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.StartupHelper;
using SupermarketApp.View;
using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp
{

    public partial class MainWindow : Window
    {
        private readonly IAbstractFactory<AdminWindow> _adminWindowFactory;
        private readonly MainViewModel _mainViewModel;
        public MainWindow(IAbstractFactory<AdminWindow> adminWindowFactory, MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            DataContext = _mainViewModel;
            _adminWindowFactory = adminWindowFactory;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var userResponseDto = _mainViewModel.LoginClick();
            if (userResponseDto == null)
            {
                return;
            }
            
            if(userResponseDto.UserType == EUserType.Admin)
            {
                _adminWindowFactory.Create().Show();
            }

            if (userResponseDto.UserType == EUserType.Cashier)
            {
                // show cashier window
            }

        }
    }
}