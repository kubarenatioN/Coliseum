using System.Windows.Controls;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для EventItemControl.xaml
    /// </summary>
    public partial class EventItemControl : UserControl
    {
        public EventItemControl(Event e)
        {
            InitializeComponent();

            DataContext = new EventItemViewModel(e);
        }
    }
}
