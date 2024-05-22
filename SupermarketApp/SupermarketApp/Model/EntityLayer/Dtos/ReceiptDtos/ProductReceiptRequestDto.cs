using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class ProductReceiptRequestDto : BaseValidator, IValidatableObject
    {
        public int ReceiptId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(ReceiptId <= 0)
            {
                yield return new ValidationResult("ReceiptId must be greater than 0", new[] { nameof(ReceiptId) });
            }

            if(ProductId <= 0)
            {
                yield return new ValidationResult("ProductId must be greater than 0", new[] { nameof(ProductId) });
            }

            if(Quantity <= 0)
            {
                yield return new ValidationResult("Quantity must be greater than 0", new[] { nameof(Quantity) });
            }
        }
    }
}
