using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class UserRequestDto : BaseValidator, IValidatableObject
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public EUserType UserType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(Username))
            {
                yield return new ValidationResult("Username is required", new[] { nameof(Username) });
            }

            if(string.IsNullOrEmpty(Password))
            {
                yield return new ValidationResult("Password is required", new[] { nameof(Password) });
            }
        }
    }
}
