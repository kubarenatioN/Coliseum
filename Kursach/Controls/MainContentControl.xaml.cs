using System.Windows.Controls;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для MainContentControl.xaml
    /// </summary>
    public partial class MainContentControl : UserControl
    {
        public MainContentControl()
        {
            InitializeComponent();

            DataContext = new MainContentViewModel(header, sidebar);
        }
    }
}
