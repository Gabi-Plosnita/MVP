using SupermarketApp.Commands;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System.Windows.Controls;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        private string _username = "";
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _password = "";

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ICommand LoginCommand { get; private set; }
        public LoginViewModel()
        {
            _userService = new UserService();
            LoginCommand = new RelayCommand<object>(Login);
        }

        private void Login(object? obj)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                System.Windows.MessageBox.Show("Please enter username and password");
                return;
            }

            var currentPage = obj as Page;
            if (currentPage is not Page)
            {
                return;
            }

            try
            {
                var userResponseDto = _userService.Login(Username, Password);
                Username = string.Empty;
                Password = string.Empty;
                if (userResponseDto == null)
                {
                    return;
                }

                if (userResponseDto.UserType == EUserType.Admin)
                {
                    AdminPage adminPage = new AdminPage();
                    currentPage.NavigationService?.Navigate(adminPage);
                }

                if (userResponseDto.UserType == EUserType.Cashier)
                {
                    CashierPage cashierPage = new CashierPage(userResponseDto);
                    currentPage.NavigationService?.Navigate(cashierPage);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return;
            }

        }
    }
}
