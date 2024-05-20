using SupermarketApp.Commands;
using System.Windows.Input;
using SupermarketApp.Notification;
using SupermarketApp.Model.BusinessLogicLayer.Services;

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

        public ICommand LoginClickCommand { get; private set; }

        public MainViewModel(IUserService userService)
        {
            _userService = userService;
            LoginClickCommand = new RelayCommand<Object>(LoginClick);
        }

        private void LoginClick(object parameter)
        {
            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                System.Windows.MessageBox.Show("Please enter username and password");
            }
            
            try
            {
                var userResponseDto= _userService.Login(Username, Password);
                _username = string.Empty;
                _password = string.Empty;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
