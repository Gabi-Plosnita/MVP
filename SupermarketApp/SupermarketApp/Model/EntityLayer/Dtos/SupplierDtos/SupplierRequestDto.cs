using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class SupplierRequestDto : BaseValidator, IValidatableObject
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            }

            if(string.IsNullOrEmpty(Country))
            {
                yield return new ValidationResult("Country is required", new[] { nameof(Country) });
            }
        }
    }
}
