using SupermarketApp.Commands;
using System.Windows.Input;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;

namespace SupermarketApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }

        public MainViewModel()
        {
            // Initialize Services //
            _userService = new UserService();

            // Initialize Commands //
            LoginCommand = new RelayCommand<object>(LoginClick);
        }

        public void LoginClick(object param)
        {
            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                System.Windows.MessageBox.Show("Please enter username and password");
                return;
            }
            
            try
            {
                var userResponseDto= _userService.Login(Username, Password);
                Username = string.Empty;
                Password = string.Empty;
                if (userResponseDto == null)
                {
                    return;
                }

                if (userResponseDto.UserType == EUserType.Admin)
                {
                    AdminWindow adminView = new AdminWindow();
                    adminView.Show();
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
