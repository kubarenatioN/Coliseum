using System.Windows.Controls;

namespace Kursach.Views
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage(Game g)
        {
            InitializeComponent();

            DataContext = new GamePageViewModel(g);
        }
    }
}
