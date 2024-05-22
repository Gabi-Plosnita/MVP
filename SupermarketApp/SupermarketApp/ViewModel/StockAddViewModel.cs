using SupermarketApp.Commands;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    public class StockAddViewModel : BaseViewModel
    {
        private readonly IStockService _stockService = new StockService();
        private readonly IProductService _productService = new ProductService();

        public StockResponseDto EditingStock { get; set; }
        public int Quantity { get; set; }
        private ObservableCollection<string> _unitTypes { get; set; }
        public ObservableCollection<string> UnitTypes
        {
            get { return _unitTypes; }
            set
            {
                _unitTypes = value;
                NotifyPropertyChanged();
            }
        }
        public string SelectedUnitType { get; set; }
        public DateTime SupplyDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double PurchasePrice { get; set; }
        public double SellingPrice { get; set; }
        public ObservableCollection<ProductResponseDto> Products { get; set; }
        public ProductResponseDto SelectedProduct { get; set; }
        public ICommand SaveStockCommand { get; set; }

        public StockAddViewModel()
        {
            Products = new ObservableCollection<ProductResponseDto>(_productService.GetAllProducts());
            UnitTypes = new ObservableCollection<string>
            {
                EUnitType.Piece.ToString(),
                EUnitType.Kilogram.ToString(),
                EUnitType.Liter.ToString()
            };
            SaveStockCommand = new RelayCommand<object>(SaveStock);
        }

        private void SaveStock(object obj)
        {
            if(SelectedProduct == null)
            {
                MessageBox.Show("Please select a product");
                return;
            }
            if(SelectedUnitType == null)
            {
                MessageBox.Show("Please select a unit type");
                return;
            }
            if(SupplyDate == null)
            {
                MessageBox.Show("Please select a supply date");
                return;
            }
            if(ExpiryDate == null)
            {
                MessageBox.Show("Please select an expiry date");
                return;
            }

            var stockRequestto = new StockRequestDto
            {
                ProductId = SelectedProduct.ProductId,
                Quantity = Quantity,
                //UnitType = (EUnitType)Enum.Parse(typeof(EUnitType), SelectedUnitType),
                SupplyDate = SupplyDate,
                ExpirationDate = ExpiryDate,
                PurchasePrice = PurchasePrice,
            };

            string validationMessage = stockRequestto.GetValidationErrorMessage();
            if(!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            try
            {
                _stockService.AddStock(stockRequestto);
                MessageBox.Show("Stock added successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            var currentPage = obj as Page;
            var adminPage = new AdminPage();
            currentPage.NavigationService?.Navigate(adminPage);
        }
    }
}
