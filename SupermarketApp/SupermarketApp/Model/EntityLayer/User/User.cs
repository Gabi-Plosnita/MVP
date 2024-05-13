﻿namespace SupermarketApp.Model.EntityLayer
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public EUserType UserType { get; set; }

        public bool IsActive { get; set; }

    }
}