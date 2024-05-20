using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class CategoryRequestDto : BaseValidator, IValidatableObject
    {
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            }
        }
    }
}
