using Kursach.Views;
using System.Windows.Media;

namespace Kursach
{
    public class FriendItemViewModel : BaseViewModel
    {
        private MainContentViewModel mainVM;
        public User User { get; set; }
        public UserPublicInfo UserPublic { get; set; }
        public ImageSource UserAvatar { get; set; }

        public RelayCommand OpenUserPageCommand { get; set; }

        public FriendItemViewModel(User user)
        {
            mainVM = MainContentViewModel.Instance;

            // fill props with data
            User = user;
            UserPublic = user.UserPublicInfo;
            UserAvatar = ImageConverter.ImageSourceFromByteArray(user.UserAccountInfo.AvatarImage);
            
            OpenUserPageCommand = new RelayCommand(async () => await mainVM.OpenPage(new UserPage(User)));
        }
    }
}
