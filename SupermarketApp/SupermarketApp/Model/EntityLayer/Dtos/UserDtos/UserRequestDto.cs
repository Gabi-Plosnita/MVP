using System.ComponentModel.DataAnnotations;

namespace SupermarketApp.Model.EntityLayer
{
    public class UserRequestDto
    {
        [Required(ErrorMessage = "Username is required and can't be empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required and can't be empty")]
        public string Password { get; set; }

        [Required(ErrorMessage = "UserType is required and can't be empty")]
        public EUserType UserType { get; set; }
    }
}
