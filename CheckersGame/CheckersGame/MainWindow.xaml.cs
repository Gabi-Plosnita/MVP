using System.Windows;
using CheckersGame.ViewModel;

namespace CheckersGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainViewModel mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            InitializeComponent();
        }
    }
}
