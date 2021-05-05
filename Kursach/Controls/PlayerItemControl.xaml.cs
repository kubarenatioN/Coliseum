using System.Windows.Controls;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для PlayerItemControl.xaml
    /// </summary>
    public partial class PlayerItemControl : UserControl
    {
        public PlayerItemControl(Player p)
        {
            InitializeComponent();

            DataContext = new PlayerItemViewModel(p);
        }
    }
}
