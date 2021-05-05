using System.Windows;
using System.Windows.Controls;

namespace Kursach.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindowStartPage.xaml
    /// </summary>
    public partial class LoginWindowStartPage : Page
    {
        public LoginWindowStartPage()
        {
            InitializeComponent();

            DataContext = new LoginStartPageViewModel();
        }
    }
}
