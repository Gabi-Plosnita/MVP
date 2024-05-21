﻿using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.ViewModel
{
    public class AdminViewModel
    {
        private readonly IUserService _userService;

        public AdminViewModel()
        {
            // Initialize services //
            _userService = new UserService();
        }
    }
}
