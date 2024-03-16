namespace Tema1.Backend
{
    public class Admin
    {
        private string UserName;

        private string Password;

        public bool ValidUsername(string username)
        {
            return string.Equals(UserName, username);
        }

        public bool ValidPassword(string password)
        {
            return string.Equals(Password, password);
        }
    }
}
