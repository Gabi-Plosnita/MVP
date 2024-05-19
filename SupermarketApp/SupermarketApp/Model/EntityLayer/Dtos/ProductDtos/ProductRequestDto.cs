using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class ProductRequestDto
    {
        [Required(ErrorMessage = "Name is required and can't be empty")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Barcode is required and can't be empty")]
        public string Barcode { get; set; }


        [Required(ErrorMessage = "CategoryId is required and can't be empty")]
        [Range(0, int.MaxValue, ErrorMessage = "Category Id must be at least 0")]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "SupplierId is required and can't be empty")]
        [Range(0, int.MaxValue, ErrorMessage = "Supplier Id is required and must be at least 0")]
        public int SupplierId { get; set; }
    }
}
