using SupermarketApp.Model.BusinessLogicLayer.Mappers;
using SupermarketApp.Model.DataAccessLayer.Repository;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptService(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public int AddReceipt(int cashierId)
        {
            try
            {
                var receipt = new Receipt
                {
                    CashierId = cashierId
                };
                int receiptId = _receiptRepository.AddReceipt(receipt);
                return receiptId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddProductReceipt(ProductReceiptRequestDto productReceiptDto)
        {
            try
            {
                var productReceipt = productReceiptDto.MapToProductReceipt();
                _receiptRepository.AddProductReceipt(productReceipt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void PayReceipt(int receiptId)
        {
            try
            {
                _receiptRepository.PayReceipt(receiptId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ReceiptResponseDto> GetReceipts()
        {
            var receipts = _receiptRepository.GetReceipts();
            var receiptDtos = receipts.MapToListOfReceiptResponseDto();
            return receiptDtos;
        }

        public ReceiptResponseDto GetReceipt(int receiptId)
        {
            try
            {
                var receipt = _receiptRepository.GetReceipt(receiptId);
                var receiptDto = receipt.MapToReceiptResponseDto();
                return receiptDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
