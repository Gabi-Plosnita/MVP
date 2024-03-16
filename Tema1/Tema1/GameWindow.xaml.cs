using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tema1
{
    public partial class GameWindow : Window
    {
        private List<(string, string)> hints;
        public GameWindow()
        {
            InitializeComponent();
            hints = MainWindow.englishDictionary.GenerateHints(5);
        }
    }
}
