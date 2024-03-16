namespace Tema1.Backend
{
    public class Admin
    {
        private string UserName;

        private string Password;

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
