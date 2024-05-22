using SupermarketApp.Commands;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    public class CashierViewModel : BaseViewModel
    {
        private readonly IProductService _productService;

        private readonly IReceiptService _receiptService;
        public UserResponseDto Cashier { get; set; }
        public ObservableCollection<ProductResponseDto> Products { get; set; }
        public ProductResponseDto SelectedProduct { get; set; }
        public ReceiptResponseDto Receipt { get; set; }
        private int CurrentReceiptId { get; set; }
        public int Quantity { get; set; }
        public ICommand CreateReceiptCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand PayReceiptCommand { get; set; }
        public ICommand SearchProductCommand { get; set; }

        public CashierViewModel(UserResponseDto cashier)
        {
            Cashier = cashier;
            CurrentReceiptId = 0;

            _productService = new ProductService();
            _receiptService = new ReceiptService();

            Products = new ObservableCollection<ProductResponseDto>(_productService.GetAllProducts());
            SelectedProduct = Products.FirstOrDefault();

            CreateReceiptCommand = new RelayCommand<object>(CreateReceipt);
            AddProductCommand = new RelayCommand<object>(AddProduct);
            PayReceiptCommand = new RelayCommand<object>(PayReceipt);
            SearchProductCommand = new RelayCommand<string>(SearchProduct);
        }

        void CreateReceipt(object obj)
        {
            if(CurrentReceiptId == 0)
            {
                int id = Cashier.UserId;
                CurrentReceiptId = _receiptService.AddReceipt(id);
                MessageBox.Show("Receipt created successfully");
            }
            else
            {
                MessageBox.Show("Receipt already created. You must pay the current receipt before creating a new one!");
                return;
            }
        }

        void AddProduct(object obj)
        {
            if(CurrentReceiptId == 0)
            {
                MessageBox.Show("You must create a receipt first!");
                return;
            }
            if(SelectedProduct == null)
            {
                MessageBox.Show("You must select a product first!");
                return;
            }


            ProductReceiptRequestDto productReceiptDto = new ProductReceiptRequestDto
            {
                ReceiptId = CurrentReceiptId,
                ProductId = SelectedProduct.ProductId,    
                Quantity = this.Quantity,
            };

            string validationMessage = productReceiptDto.GetValidationErrorMessage();
            if(!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            try
            {
                _receiptService.AddProductReceipt(productReceiptDto);
                MessageBox.Show("Product added to receipt successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void PayReceipt(object obj)
        {
            if(CurrentReceiptId == 0)
            {
                MessageBox.Show("You must create a receipt first!");
                return;
            }

            try
            {
                _receiptService.PayReceipt(CurrentReceiptId);
                MessageBox.Show("Receipt paid successfully");
                CurrentReceiptId = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        void SearchProduct(object obj)
        {
            // to be implemented
        }
    }
}
