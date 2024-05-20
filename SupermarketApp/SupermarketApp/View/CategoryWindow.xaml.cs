using SupermarketApp.ViewModel;
using System.Windows;

namespace SupermarketApp.View
{
    public partial class CategoryWindow : Window
    {
        private readonly CategoryViewModel _categoryViewModel;
        public CategoryWindow(CategoryViewModel categoryViewModel)
        {
            InitializeComponent();

            _categoryViewModel = categoryViewModel;
            DataContext = _categoryViewModel;
        }
    }
}
