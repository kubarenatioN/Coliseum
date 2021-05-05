using System.Windows.Controls;

namespace Kursach.Views
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            
            DataContext = new HomeViewModel();
        }
    }
}
