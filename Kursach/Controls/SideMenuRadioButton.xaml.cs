using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для SideMenuRadioButton.xaml
    /// </summary>
    public partial class SideMenuRadioButton : UserControl
    {

        public Geometry ItemImage
        {
            get { return (Geometry)GetValue(ItemImageProperty); }
            set { SetValue(ItemImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemImageProperty =
            DependencyProperty.Register("ItemImage", typeof(Geometry), typeof(SideMenuRadioButton), new PropertyMetadata());



        public string ItemTitle
        {
            get { return (string)GetValue(ItemTitleProperty); }
            set { SetValue(ItemTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemTitleProperty =
            DependencyProperty.Register("ItemTitle", typeof(string), typeof(SideMenuRadioButton), new PropertyMetadata());



        public SideMenuRadioButton()
        {
            InitializeComponent();
        }
    }
}
