using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class CategoryRequestDto
    {
        [Required(ErrorMessage = "Name is required and can't be empty")]
        public string Name { get; set; }
    }
}
