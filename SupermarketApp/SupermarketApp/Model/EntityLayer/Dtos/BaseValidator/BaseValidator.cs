using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public abstract class BaseValidator
    {
        public string GetValidationErrorMessage()
        {
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);

            var errorMessage = string.Join(Environment.NewLine, validationResults.Select(vr => vr.ErrorMessage));
            return errorMessage;
        }
    }
}
