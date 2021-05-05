using System.Windows.Controls;

namespace Kursach.Views
{
    /// <summary>
    /// Логика взаимодействия для TeamsPage.xaml
    /// </summary>
    public partial class TeamsPage : Page
    {
        public TeamsPage()
        {
            InitializeComponent();

            DataContext = new TeamsViewModel();
        }
    }
}
