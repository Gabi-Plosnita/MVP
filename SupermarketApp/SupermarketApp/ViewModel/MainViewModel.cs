using SupermarketApp.Commands;
using System.Windows.Input;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;

namespace SupermarketApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private Object? _currentPage;
        public Object? CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            var loginPage = new LoginPage();
            CurrentPage = loginPage;
        }
    }
}
