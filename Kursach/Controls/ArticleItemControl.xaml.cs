using System.Windows.Controls;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для ArticleItemControl.xaml
    /// </summary>
    public partial class ArticleItemControl : UserControl
    {
        public ArticleItemControl(Article a)
        {
            InitializeComponent();

            DataContext = new ArticleItemViewModel(a);
        }
    }
}
