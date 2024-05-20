using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class ProductRequestDto : BaseValidator, IValidatableObject
    {
        public string Name { get; set; }

        public string Barcode { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            }

            if(string.IsNullOrEmpty(Barcode))
            {
                yield return new ValidationResult("Barcode is required", new[] { nameof(Barcode) });
            }

            if(CategoryId <= 0)
            {
                yield return new ValidationResult
                    ("CategoryId is required and must be greater than 0", new[] { nameof(CategoryId) });
            }

            if(SupplierId <= 0)
            {
                yield return new ValidationResult
                    ("SupplierId is required and must be greater than 0", new[] { nameof(SupplierId) });
            }
        }
    }
}
