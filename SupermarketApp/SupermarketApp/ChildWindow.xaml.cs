using SupermarketApp.Model.DataAccessLayer.Repository;
using System.Windows;


namespace SupermarketApp
{
    public partial class ChildWindow : Window
    {
        private readonly IRepository _repository;
        public ChildWindow(IRepository repository)
        {
            _repository = repository;
            repository.Method();
            InitializeComponent();
        }
    }
}
