﻿using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        public User Login(string username, string password);

        public List<User> GetUsers();

        public User GetUser(int id);

        public void AddUser(User user);

        public void UpdateUser(int id, User updatedUser);

        public void DeleteUser(int id);

    }
}
