using SupermarketApp.Commands;
using System.Windows.Input;
using SupermarketApp.Notification;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.ViewModel
{
    public class MainViewModel : BaseNotification
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

        public MainViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserResponseDto LoginClick()
        {
            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                System.Windows.MessageBox.Show("Please enter username and password");
                return null;
            }
            
            try
            {
                var userResponseDto= _userService.Login(Username, Password);
                Username = string.Empty;
                Password = string.Empty;
                return userResponseDto;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
