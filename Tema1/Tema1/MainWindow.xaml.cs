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

            List<string> words = new List<string>();
            foreach (Word word in englishDictionary.ListOfWords)
            {
                words.Add(word.Name);
            }
            searchBarBox.ItemsSource = words;

            List<string> categories = new List<string>();
            categories.Add("All");
            foreach(string category in englishDictionary.dictionaryByCategory.Keys)
            {
                categories.Add(category);
            }
            categoryBox.ItemsSource = categories;
        }
        private void SearchBarBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchBarBox.Text;
            Word word = englishDictionary.ListOfWords.FirstOrDefault(x => x.Name == searchText);
            if (word != null)
            {
                WordWindow wordWindow = new WordWindow(word);
                wordWindow.Show();
            }    
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           string category = categoryBox.SelectedItem as string;
           List<string> words = new List<string>();

           if(englishDictionary.dictionaryByCategory.ContainsKey(category))
           {
                foreach(Word word in englishDictionary.dictionaryByCategory[category])
                {
                    words.Add(word.Name);
                }
           }
           else
           {
               foreach(Word word in englishDictionary.ListOfWords)
               {
                   words.Add(word.Name);
               }
           }
            searchBarBox.ItemsSource = words;
        }

    }
}
