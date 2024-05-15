using SupermarketApp.Model.DataAccessLayer.Repository;
using SupermarketApp.StartupHelper;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SupermarketApp
{

    public partial class MainWindow : Window
    {
        private readonly IAbstractFactory<ChildWindow> _childWindowFactory;
        public MainWindow(IAbstractFactory<ChildWindow> childWindowFactory)
        {
            InitializeComponent();
            OpenFormButton.Click += OpenFormButton_Click;
            _childWindowFactory = childWindowFactory;
        }

        private void OpenFormButton_Click(object sender, RoutedEventArgs e)
        {
            _childWindowFactory.Create().Show();
        }
    }
}