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
        public ICommand CreateReceiptCommand { get; set; }

        public CashierViewModel(UserResponseDto cashier)
        {
            Cashier = cashier;
            CurrentReceiptId = 0;

            _productService = new ProductService();
            _receiptService = new ReceiptService();

            Products = new ObservableCollection<ProductResponseDto>(_productService.GetAllProducts());

            CreateReceiptCommand = new RelayCommand<object>(CreateReceipt);
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
            }
        }
    }
}
