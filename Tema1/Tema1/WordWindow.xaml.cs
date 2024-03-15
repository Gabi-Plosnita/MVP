using Dictionar.Backend;
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
    public partial class WordWindow : Window
    {
        public Word Word { get; set; }
        public WordWindow(Word word)
        {
            InitializeComponent();
            DataContext = this;
            Word = word;
        }
    }
}
