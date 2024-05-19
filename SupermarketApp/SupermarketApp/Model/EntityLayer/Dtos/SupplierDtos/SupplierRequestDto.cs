using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class SupplierRequestDto
    {
        [Required(ErrorMessage = "Name is required and can't be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required and can't be empty")]
        public string Country { get; set; }

    }
}
