using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class StockRequestDto : BaseValidator, IValidatableObject
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public EUnitType UnitType { get; set; }

        public DateTime SupplyDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double PurchasePrice { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(ProductId <= 0)
            {
                yield return new ValidationResult("Product Id must be greater than 0", new[] { nameof(ProductId) });
            }

            if(Quantity <= 0)
            {
                yield return new ValidationResult("Quantity must be greater than 0", new[] { nameof(Quantity) });
            }

            if(PurchasePrice <= 0)
            {
                yield return new ValidationResult("Purchase price must be greater than 0", new[] { nameof(PurchasePrice) });
            }

            if(SupplyDate >= ExpirationDate)
            {
                yield return new ValidationResult
                    ("Supply date must be less than expiration date", new[] { nameof(SupplyDate), nameof(ExpirationDate) });
            }
        }
    }
}
