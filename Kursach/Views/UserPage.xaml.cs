using System.Windows.Controls;

namespace Kursach.Views
{
    /// <summary>
    /// Логика взаимодействия для UserOwnPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage(User user)
        {
            InitializeComponent();

            DataContext = new UserPageViewModel(user);
        }
    }
}
