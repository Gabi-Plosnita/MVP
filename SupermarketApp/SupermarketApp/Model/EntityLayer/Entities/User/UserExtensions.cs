namespace SupermarketApp.Model.EntityLayer
{
    public static class UserExtensions
    {
        public static void Update(this User user, User updatedUser)
        {
            user.Username = updatedUser.Username;
            user.Password = updatedUser.Password;
            user.UserType = updatedUser.UserType;
        }
    }
}
