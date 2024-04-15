using System.Windows;
using CheckersGame.View;
using CheckersGame.ViewModel;

namespace CheckersGame
{
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel { get; set; }
        public MainWindow()
        {
            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            InitializeComponent();
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statisticsWindow = new StatisticsWindow(mainViewModel.StatisticsViewModel);
            statisticsWindow.Show();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
    }
}
