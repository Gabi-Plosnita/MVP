using SupermarketApp.Model.BusinessLogicLayer.Mappers;
using SupermarketApp.Model.DataAccessLayer.Repository;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserResponseDto Login(string username, string password)
        {
            try
            {
                var user = _userRepository.Login(username, password);
                var userDto = user.MapToUserResponseDto();
                return userDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UserResponseDto> GetUsers()
        {
            var users = _userRepository.GetUsers();
            var usersDto = users.MapToListOfUserResponseDto();
            return usersDto;
        }

        public UserResponseDto GetUser(int id)
        {
            try
            {
                var user = _userRepository.GetUser(id);
                var userDto = user.MapToUserResponseDto();
                return userDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddUser(UserRequestDto userDto)
        {
            try
            {
                var user = userDto.MapToUser();
                _userRepository.AddUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUser(int id, UserRequestDto updatedUserDto)
        {
            try
            {
                var user = updatedUserDto.MapToUser();
                _userRepository.UpdateUser(id, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
