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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema1
{
    public partial class MainWindow : Window
    {
        EnglishDictionary englishDictionary { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            englishDictionary = new EnglishDictionary();
            englishDictionary.LoadFromFile("../../Resources/Files/dictionary.json");

            string[] words = englishDictionary.ListOfWords.Select(x => x.Name).ToArray();
            searchBarBox.ItemsSource = words;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Word word = new Word();
            word.Name = "ana";
            word.Description = "are";
            word.Category = "mere";
            word.Image = "D:/Facultate/An_2_Semestru_2/MVP/MVP/Tema1/Tema1/Resources/Images/NoImage.jpg";

            WordWindow secondWindow = new WordWindow(word);
            secondWindow.Show();
        }
    }
}
