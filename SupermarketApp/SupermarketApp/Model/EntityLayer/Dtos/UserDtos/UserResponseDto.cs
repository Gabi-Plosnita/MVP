namespace SupermarketApp.Model.EntityLayer
{
    public class UserResponseDto
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public EUserType UserType { get; set; }

    }
}
