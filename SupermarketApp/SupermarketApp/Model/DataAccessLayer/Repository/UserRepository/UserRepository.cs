using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(SupermarketDbContext context) : base(context)
        {
        }

        public User Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new Exception($"User with name {username} not found");
            }

            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            return user;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception($"User with id {id} not found");
            }

            return user;
        }

        public void AddUser(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
            {
                throw new Exception($"User with name {user.Username} already exists");
            }

            if (user.Username == "" || user.Password == "")
            {
                throw new Exception("Username and password can't be empty");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(int id, User updatedUser)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception($"User with id {id} not found");
            }

            if (_context.Users.Any(u => u.Username == updatedUser.Username))
            {
                throw new Exception($"User with name {updatedUser.Username} already exists");
            }

            if (updatedUser.Username == "" || updatedUser.Password == "")
            {
                throw new Exception("Username and password can't be empty");
            }

            _context.Entry(user).CurrentValues.SetValues(updatedUser);
            _context.SaveChanges();

        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception($"User with id {id} not found");
            }

            user.IsActive = false;
            _context.SaveChanges();
        }

    }
}
