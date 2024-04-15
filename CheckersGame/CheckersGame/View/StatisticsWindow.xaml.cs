using CheckersGame.ViewModel;
using System.Windows;

namespace CheckersGame.View
{
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow(StatisticsViewModel statisticsViewModel)
        {
            DataContext = statisticsViewModel;
            InitializeComponent();
        }
    }
}
