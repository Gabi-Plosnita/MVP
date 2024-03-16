namespace Tema1.Backend
{
    public class Admin
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsValidUsername(string username)
        {
            return string.Equals(UserName, username);
        }

        public bool IsValidPassword(string password)
        {
            return string.Equals(Password, password);
        }
    }
}
