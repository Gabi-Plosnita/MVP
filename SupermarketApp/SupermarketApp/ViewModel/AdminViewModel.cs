using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.ViewModel
{
    public class AdminViewModel
    {
        private readonly IUserService _userService;
        public UserResponseDto User { get; set; }

        public AdminViewModel(IUserService userService)
        {
            _userService = userService;
        }
    }
}
