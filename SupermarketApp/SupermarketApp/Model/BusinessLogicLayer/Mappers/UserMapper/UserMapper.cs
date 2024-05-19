using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Mappers
{
    public static class UserMapper
    {
        public static UserResponseDto MapToUserResponseDto(this User user)
        {
            return new UserResponseDto
            {
                UserId = user.UserId,
                Username = user.Username,
                UserType = user.UserType
            };
        }

        public static List<UserResponseDto> MapToListOfUserResponseDto(this List<User> users)
        {
            return users.Select(user => user.MapToUserResponseDto()).ToList();
        }

        public static User MapToUser(this UserRequestDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                UserType = userDto.UserType
            };
        }
    }
}
