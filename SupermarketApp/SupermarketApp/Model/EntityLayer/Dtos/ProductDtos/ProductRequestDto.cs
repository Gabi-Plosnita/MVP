using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class ProductRequestDto
    {
        [Required(ErrorMessage = "Name is required and can't be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Barcode is required and can't be empty")]
        public string Barcode { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

    }
}
