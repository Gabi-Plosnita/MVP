using SupermarketApp.Model.EntityLayer;
using SupermarketApp.ViewModel;
using System.Windows.Controls;

namespace SupermarketApp.View
{
    public partial class UserEditPage : Page
    {
        public UserEditPage()
        {
            InitializeComponent();
            DataContext = new UserEditViewModel();
        }

        public UserEditPage(UserResponseDto user)
        {
            InitializeComponent();
            DataContext = new UserEditViewModel(user);
        }
    }
}
