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
using Tema1.Backend.Dictionary;
using PropertyChanged;

namespace Tema1
{
    [AddINotifyPropertyChangedInterface]
    public partial class GameWindow : Window
    {
        private List<Hint> Hints;

        private int WordCount;

        public int WordsGuessed { get; set; }

        public string Message { get; set; }

        public string HintDescription { get; set; }

        public string HintImage { get; set; }

        public GameWindow()
        {
            InitializeComponent();
            DataContext = this;
            InitializeWindow();
        }
        private void InitializeWindow()
        {
            Hints = MainWindow.englishDictionary.GenerateHints(5);
            WordCount = 0;
            WordsGuessed = 0;

            if (Hints[WordCount].HintType == "description")
            {
                HintDescription = Hints[WordCount].HintValue;
                HintImage = "";
            }
            else
            {
                HintImage = Hints[WordCount].HintValue;
                HintDescription = "";
            }
            Message = "";
        }

        private void VerifyButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (string.Equals(answerField.Text.ToLower(), Hints[WordCount].WordName.ToLower()))
            {
                WordsGuessed++;
                Message = "Correct answer";
            }
            else
            {
                Message = $"Incorrect answer. The correct answer was: {Hints[WordCount].WordName}.";
            }

            answerField.Text = "";

            WordCount++;
            if (WordCount == Hints.Count)
            {
                VerifyButton.IsEnabled = false;
                Message = "Game Over! Restart the game to play again!";
                return;
            }

            if (Hints[WordCount].HintType == "description")
            {
                HintDescription = Hints[WordCount].HintValue;
                HintImage = "";
            }
            else
            {
                HintImage = Hints[WordCount].HintValue;
                HintDescription = "";
            }
        }

        private void RestartButton_Clicked(object sender, RoutedEventArgs e)
        {
            InitializeWindow();
            VerifyButton.IsEnabled = true;
            answerField.Text = "";
        }
    }
}
