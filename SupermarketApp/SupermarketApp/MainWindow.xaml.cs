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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); 
            //_childWindowFactory = childWindowFactory;
        }
    }
}