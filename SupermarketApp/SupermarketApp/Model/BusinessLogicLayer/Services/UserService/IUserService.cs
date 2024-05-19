using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public interface IUserService
    {
        public UserResponseDto Login(string username, string password);

        public List<UserResponseDto> GetUsers();

        public UserResponseDto GetUser(int id);

        public void AddUser(UserRequestDto userDto);

        public void UpdateUser(int id, UserRequestDto updatedUserDto);

        public void DeleteUser(int id);
    }
}
