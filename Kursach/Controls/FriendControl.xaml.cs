using System.Windows;
using System.Windows.Controls;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для FriendControl.xaml
    /// </summary>
    public partial class FriendControl : UserControl
    {
        public Visibility IsInviteButtonVisible
        {
            get { return (Visibility)GetValue(IsInviteButtonVisibleProperty); }
            set { SetValue(IsInviteButtonVisibleProperty, value); }
        }
        
        public static readonly DependencyProperty IsInviteButtonVisibleProperty =
            DependencyProperty.Register("IsInviteButtonVisible", typeof(Visibility), typeof(FriendControl), new PropertyMetadata(Visibility.Hidden));


        public FriendControl(User user)
        {
            InitializeComponent();

            DataContext = new FriendItemViewModel(user);
        }
    }
}
