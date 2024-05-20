using SupermarketApp.Model.DataAccessLayer.Repository;
using SupermarketApp.StartupHelper;
using SupermarketApp.ViewModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SupermarketApp
{

    public partial class MainWindow : Window
    {
        //private readonly IAbstractFactory<ChildWindow> _childWindowFactory;
        private readonly MainViewModel _mainViewModel;
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            DataContext = _mainViewModel;
            //_childWindowFactory = childWindowFactory;
        }
    }
}