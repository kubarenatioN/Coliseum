using System.Windows;
using System.Windows.Controls;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для PageHeaderControl.xaml
    /// </summary>
    public partial class PageHeaderControl : UserControl
    {

        public string HeaderTitle
        {
            get { return (string)GetValue(HeaderTitleProperty); }
            set { SetValue(HeaderTitleProperty, value); }
        }
        
        public static readonly DependencyProperty HeaderTitleProperty =
            DependencyProperty.Register("HeaderTitle", typeof(string), typeof(PageHeaderControl), new PropertyMetadata(""));


        public string HeaderSubtitle
        {
            get { return (string)GetValue(HeaderSubtitleProperty); }
            set { SetValue(HeaderSubtitleProperty, value); }
        }
        
        public static readonly DependencyProperty HeaderSubtitleProperty =
            DependencyProperty.Register("HeaderSubtitle", typeof(string), typeof(PageHeaderControl), new PropertyMetadata(""));


        public string BackgroundImage
        {
            get { return (string)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }
        
        public static readonly DependencyProperty BackgroundImageProperty =
            DependencyProperty.Register("BackgroundImage", typeof(string), typeof(PageHeaderControl));



        public PageHeaderControl()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
