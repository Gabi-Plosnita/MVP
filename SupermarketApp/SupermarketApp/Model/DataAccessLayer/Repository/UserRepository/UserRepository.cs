﻿using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(SupermarketDbContext context) : base(context)
        {
        }

        // User Methods //
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

        // Recipts Methods //

        public void AddReceipt(Receipt receipt)
        {
            var cashier = _context.Users.Find(receipt.CashierId);
            if (cashier == null)
            {
                throw new Exception($"User with id {receipt.CashierId} not found");
            }

            receipt.DateOfIssue = DateTime.Now;

            _context.Receipts.Add(receipt);
            _context.SaveChanges();
        }

        public void AddProductReceipt(ProductReceipt productReceipt)
        {
            var receipt = _context.Receipts.Find(productReceipt.ReceiptId);

            if (receipt == null)
            {
                throw new Exception($"Receipt with id {productReceipt.ReceiptId} not found");
            }

            if (receipt.IsPaid)
            {
                throw new Exception($"Can't modify receipt with id {productReceipt.ReceiptId}");
            }

            var product = _context.Products.Find(productReceipt.ProductId);
            if (product == null)
            {
                throw new Exception($"Product with id {productReceipt.ProductId} not found");
            }

            if (productReceipt.Quantity <= 0)
            {
                throw new Exception("Quantity must be greater than 0");
            }

            var stock = _context.Stocks.Where(s => s.ProductId == productReceipt.ProductId)
                                      .OrderBy(s => s.SupplyDate)
                                      .FirstOrDefault();

            if (stock == null)
            {
                throw new Exception($"Product with id {productReceipt.ProductId} is out of stock");
            }

            if (stock.ExpirationDate < DateTime.Now)
            {
                throw new Exception($"Product with id {productReceipt.ProductId} is expired");
            }

            if (stock.Quantity < productReceipt.Quantity)
            {
                throw new Exception
                    ($"There are only {stock.Quantity} products in the current stock. You can't buy {productReceipt.Quantity} products");
            }

            stock.Quantity -= productReceipt.Quantity;
            if (stock.Quantity == 0)
            {
                stock.IsActive = false;
            }

            productReceipt.UnitType = stock.UnitType;
            productReceipt.Subtotal = productReceipt.Quantity * stock.SalePrice;

            _context.ProductReceipts.Add(productReceipt);
            _context.SaveChanges();
        }

        public void PayReceipt(int receiptId)
        {
            var receipt = _context.Receipts.Find(receiptId);

            if (receipt == null)
            {
                throw new Exception($"Receipt with id {receiptId} not found");
            }

            if (receipt.IsPaid)
            {
                throw new Exception($"Receipt with id {receiptId} is already paid");
            }

            foreach(var productReceipt in receipt.ProductReceipts)
            {
                receipt.TotalPrice += productReceipt.Subtotal;
            }

            receipt.IsPaid = true;
            _context.SaveChanges();
        }
    }
}
