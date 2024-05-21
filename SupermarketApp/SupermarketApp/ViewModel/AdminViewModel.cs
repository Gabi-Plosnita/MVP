using SupermarketApp.Commands;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    public class AdminViewModel : BaseViewModel
    {
        private readonly IUserService _userService = new UserService();
        private readonly IProductService _productService = new ProductService();
        private readonly ICategoryService _categoryService = new CategoryService();
        private readonly ISupplierService _supplierService = new SupplierService();
        private readonly IStockService _stockService = new StockService();
        private readonly IReceiptService _receiptService = new ReceiptService();

        public ObservableCollection<UserResponseDto> Users { get; set; }
        public ObservableCollection<ReceiptResponseDto> Receipts { get; set; }
        public ObservableCollection<ProductResponseDto> Products { get; set; }
        public ObservableCollection<CategoryResponseDto> Categories { get; set; }
        public ObservableCollection<SupplierResponseDto> Suppliers { get; set; }
        public ObservableCollection<StockResponseDto> Stocks { get; set; }

        public UserResponseDto SelectedUser { get; set; }
        public CategoryResponseDto SelectedCategory { get; set; }
        public ProductResponseDto SelectedProduct { get; set; }
        public SupplierResponseDto SelectedSupplier { get; set; }
        public StockResponseDto SelectedStock { get; set; }
        public ICommand AddUserCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand AddCategoryCommand { get; set; }
        public ICommand EditCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }
        public ICommand AddProducerCommand { get; set; }
        public ICommand EditProducerCommand { get; set; }
        public ICommand DeleteProducerCommand { get; set; }
        public ICommand AddStockCommand { get; set; }
        public ICommand EditStockCommand { get; set; }
        public ICommand DeleteStockCommand { get; set; }

        public AdminViewModel()
        {
            Users = new ObservableCollection<UserResponseDto>(_userService.GetUsers());
            Products = new ObservableCollection<ProductResponseDto>(_productService.GetAllProducts());
            Categories = new ObservableCollection<CategoryResponseDto>(_categoryService.GetCategories());
            Suppliers = new ObservableCollection<SupplierResponseDto>(_supplierService.GetSuppliers());
            Stocks = new ObservableCollection<StockResponseDto>(_stockService.GetStocks());
            Receipts = new ObservableCollection<ReceiptResponseDto>(_receiptService.GetReceipts());

            AddUserCommand = new RelayCommand<object>(AddUser);
            EditUserCommand = new RelayCommand<object>(EditUser);
            DeleteUserCommand = new RelayCommand<object>(DeleteUser);

            AddCategoryCommand = new RelayCommand<object>(AddCategory);
            EditCategoryCommand = new RelayCommand<object>(EditCategory);
            DeleteCategoryCommand = new RelayCommand<object>(DeleteCategory);

            AddProductCommand = new RelayCommand<object>(AddProduct);
            EditProductCommand = new RelayCommand<object>(EditProduct);
            DeleteProductCommand = new RelayCommand<object>(DeleteProduct);

            AddProducerCommand = new RelayCommand<object>(AddProducer);
            EditProducerCommand = new RelayCommand<object>(EditProducer);
            DeleteProducerCommand = new RelayCommand<object>(DeleteProducer);

            AddStockCommand = new RelayCommand<object>(AddStock);
            EditStockCommand = new RelayCommand<object>(EditStock);
            DeleteStockCommand = new RelayCommand<object>(DeleteStock);
        }

        private void AddUser(object? obj)
        {
            /*if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditUserPage());*/

        }

        private void EditUser(object? obj)
        {
           /* if (SelectedUser == null)
            {
                return;
            }
            User user = SelectedUser;
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditUserPage(user));*/
        }
        private void DeleteUser(object? obj)
        {
            /*if (SelectedUser == null)
            {
                return;
            }
            User user = SelectedUser;
            _userBLL.DeleteUser(user);
            Users.Remove(user);*/
        }

        private void AddCategory(object? obj)
        {
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }
            CategoryEditPage categoryEditPage = new CategoryEditPage();
            currentPage.NavigationService?.Navigate(categoryEditPage);
        }

        private void EditCategory(object? obj)
        {
            if(SelectedCategory == null)
            {
                MessageBox.Show("Please select a category to edit!");
                return;
            }
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }
            CategoryEditPage categoryEditWindow = new CategoryEditPage(SelectedCategory);
            currentPage.NavigationService?.Navigate(categoryEditWindow);
        }

        private void DeleteCategory(object? obj)
        {
            if(SelectedCategory == null)
            {
                MessageBox.Show("Please select a category to delete!");
                return;
            }
            _categoryService.DeleteCategory(SelectedCategory.CategoryId);
            Categories.Remove(SelectedCategory);
        }

        private void AddProduct(object? obj)
        {
           /* if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditProductPage());*/
        }

        private void EditProduct(object? obj)
        {
           /* if (SelectedProduct == null)
            {
                return;
            }
            Product product = SelectedProduct;
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditProductPage(product));*/
        }
        private void DeleteProduct(object? obj)
        {
           /* if (SelectedProduct == null)
            {
                return;
            }
            Product product = SelectedProduct;
            _productBLL.DeleteProduct(product);
            Products.Remove(product);*/
        }
        private void AddProducer(object? obj)
        {
            /*if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditProducerPage());*/
        }
        private void EditProducer(object? obj)
        {
            /*if (SelectedProducer == null)
            {
                return;
            }
            Producer producer = SelectedProducer;
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditProducerPage(producer));*/
        }
        private void DeleteProducer(object? obj)
        {
            /*if (SelectedProducer == null)
            {
                return;
            }
            Producer producer = SelectedProducer;
            _producerBLL.DeleteProducer(producer);
            Producers.Remove(producer);*/

        }
        private void AddStock(object? obj)
        {
            /*if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditStockPage());*/
        }
        private void EditStock(object? obj)
        {
            /*if (SelectedStock == null)
            {
                return;
            }
            Stock stock = SelectedStock;
            if (obj is not AdminPage currentPage)
            {
                Console.WriteLine("Current page is not AdminPage");
                return;

            }

            currentPage.NavigationService?.Navigate(new EditStockPage(stock));*/
        }
        private void DeleteStock(object? obj)
        {
            /*if (SelectedStock == null)
            {
                return;
            }
            Stock stock = SelectedStock;
            _stockBLL.DeleteStock(stock);
            Stocks.Remove(stock);*/
        }
    }

}
