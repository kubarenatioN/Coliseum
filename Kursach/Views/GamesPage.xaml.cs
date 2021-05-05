using System.Windows.Controls;

namespace Kursach.Views
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class GamesPage : Page
    {
        public GamesPage()
        {
            InitializeComponent();

            DataContext = new GamesViewModel();
        }
    }
}
