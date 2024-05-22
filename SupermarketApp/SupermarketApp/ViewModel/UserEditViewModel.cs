using SupermarketApp.Commands;
using SupermarketApp.Model.BusinessLogicLayer.Services;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SupermarketApp.ViewModel
{
    public class UserEditViewModel : BaseViewModel
    {
        private readonly IUserService _userService = new UserService();

        private bool _isEditMode;
        public UserResponseDto EditingUser { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";

        public ObservableCollection<EUserType> Roles { get; } 

        public EUserType SelectedRole { get; set; }
        public ICommand SaveUserCommand { get; set; }

        public string PageTitle
        {
            get
            {
                if (_isEditMode)
                {
                    return "Edit User";
                }
                else
                {
                    return "Add User";
                }
            }
        }

        public UserEditViewModel()
        {
            SaveUserCommand = new RelayCommand<object>(SaveUser);
            Roles = new ObservableCollection<EUserType>(Enum.GetValues(typeof(EUserType)).Cast<EUserType>());
            SelectedRole = Roles.FirstOrDefault();
            _isEditMode = false;
        }

        public UserEditViewModel(UserResponseDto user) : this()
        {
            Username = user.Username;
            Password = user.Password;
            SelectedRole = user.UserType;
            _isEditMode = true;
            EditingUser = user;
        }

        private void SaveUser(object? obj)
        { 
            if(SelectedRole == null)
            {
                MessageBox.Show("Please select a role");
                return;
            }

            var userRequestDto = new UserRequestDto()
            {
                Username = Username,
                Password = Password,
                UserType = SelectedRole
            };

            string validationMessage = userRequestDto.GetValidationErrorMessage();
            if (!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            if (_isEditMode)
            {      
                try
                {
                    int id = EditingUser.UserId;
                    _userService.UpdateUser(id, userRequestDto);
                    MessageBox.Show("User updated successfully!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    _userService.AddUser(userRequestDto);
                    MessageBox.Show("User added successfully!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            var currentPage = obj as Page;
            var adminPage = new AdminPage();
            currentPage?.NavigationService?.Navigate(adminPage);
        }
    }
}
