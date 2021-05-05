using Kursach.Views;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kursach
{
    public class WindowHeaderViewModel : BaseViewModel
    {
        public User User { get; set; }

        public ImageSource UserAvatarImage { get; set; }

        /// <summary>
        /// Command to open user's own page
        /// </summary>
        public RelayCommand OpenUserOwnPageCommand { get; set; }

        public RelayCommand SignOutCommand { get; set; }

        public WindowHeaderViewModel(User user)
        {
            // get data about logged in User
            int userId = Properties.Settings.Default.LoggedUserId;
            User = user;
            //ExplicitLoaders.LoadAllUserData(User); // ЗДЕСЬ НЕ ПОДГРУЖАЕТ ДАННЫЕ

            UserAvatarImage = ImageConverter.ImageSourceFromByteArray(User.UserAccountInfo.AvatarImage);

            OpenUserOwnPageCommand = new RelayCommand(async () => await MainContentViewModel.Instance.OpenPage(new UserOwnPage()));

            SignOutCommand = new RelayCommand(() =>
            {
                // create login window object
                LoginWindow loginWindow = new LoginWindow();

                Properties.Settings.Default.IsLoggedIn = 0;
                Properties.Settings.Default.LoggedUserId = 0;
                Properties.Settings.Default.Save();

                loginWindow.Show();

                WindowViewModel.MainWindow.Close();

            });
        }
    }
}
