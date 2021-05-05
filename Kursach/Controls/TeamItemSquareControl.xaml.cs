using System.Windows.Controls;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для TeamItemSquareControl.xaml
    /// </summary>
    public partial class TeamItemSquareControl : UserControl
    {
        public TeamItemSquareControl(Team t)
        {
            InitializeComponent();

            DataContext = new TeamItemSquareViewModel(t);
        }
    }
}
