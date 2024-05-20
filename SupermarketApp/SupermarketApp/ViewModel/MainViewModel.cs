using SupermarketApp.Commands;
using System.Windows.Input;
using SupermarketApp.Notification;

namespace SupermarketApp.ViewModel
{
    public class MainViewModel : BaseNotification
    {
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

        public MainViewModel()
        {
            LoginClickCommand = new RelayCommand<Object>(LoginClick);
        }

        private void LoginClick(object parameter)
        {
            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                System.Windows.MessageBox.Show("Please enter username and password");
            }
            else
            {
                System.Windows.MessageBox.Show("Login successful");
            }
        }
    }
}
