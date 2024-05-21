using SupermarketApp.Model.EntityLayer;
using SupermarketApp.StartupHelper;
using SupermarketApp.View;
using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}