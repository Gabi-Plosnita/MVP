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
using Tema1.Backend;

namespace Tema1
{
    public partial class MainWindow : Window
    {
        EnglishDictionary englishDictionary { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Authentication authentication = new Authentication();
            authentication.LoadFromFile("../../Resources/Files/admins.json");

            englishDictionary = new EnglishDictionary(authentication);
            englishDictionary.LoadFromFile("../../Resources/Files/dictionary.json");

            searchBarBox.ItemsSource = englishDictionary.GetAllWords();
            categoryBox.ItemsSource = englishDictionary.GetCategories();
            categoryBox.SelectedIndex = 0;
        }
        private void SearchBarBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchBarBox.Text;
            Word word = englishDictionary.GetWord(searchText);
            if (word != null)
            {
                WordWindow wordWindow = new WordWindow(word);
                wordWindow.Show();
            }    
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           string category = categoryBox.SelectedItem as string;
           List<string> words = englishDictionary.GetWordListFromCategory(category);
           searchBarBox.ItemsSource = words;
        }

        private void LoginButton_Click(Object sender, RoutedEventArgs e)
        {

        }

    }
}
