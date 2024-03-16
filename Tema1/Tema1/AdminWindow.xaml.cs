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
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            searchBarBox.ItemsSource = MainWindow.englishDictionary.GetAllWords();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchBarBox.Text;
            Word word = MainWindow.englishDictionary.GetWord(searchText);
            if (word != null)
            {
                nameField.Text = word.Name;
                categoryField.Text = word.Category;
                descriptionField.Text = word.Description;
                imageField.Text = word.Image;
            }
        }

        private void searchBarBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchBarBox.ItemsSource = MainWindow.englishDictionary.GetAllWords();
        }

        private void AddWordButton_Click(Object sender, RoutedEventArgs e)
        {
            if(string.Equals(nameField.Text,"") && string.Equals(descriptionField.Text, "") 
                && string.Equals(categoryField.Text, ""))
            {
                return;
            }
            MainWindow.englishDictionary.AddWord(nameField.Text, categoryField.Text, descriptionField.Text, imageField.Text);
        }

        private void UpdateWordButton_Click(Object sender, RoutedEventArgs e)
        {

        }

        private void DeleteWordButton_Click(Object sender, RoutedEventArgs e)
        {

        }
    }
}
