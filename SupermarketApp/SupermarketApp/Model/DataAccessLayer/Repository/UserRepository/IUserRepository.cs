using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        // User Methods //
        public User Login(string username, string password);

        public List<User> GetUsers();

        public User GetUser(int id);

        public void AddUser(User user);

        public void UpdateUser(int id, User user);

        public void DeleteUser(int id);

        // Recipts Methods //
        void AddReceipt(Receipt receipt);

        void AddProductReceipt(ProductReceipt productReceipt);

        void PayReceipt(int receiptId);
    }
}
