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

        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
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
                    // show cashier window
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
