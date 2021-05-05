using Kursach.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для GameItemControl.xaml
    /// </summary>
    public partial class GameItemControl : UserControl
    {
        //public string GameName
        //{
        //    get { return (string)GetValue(GameNameProperty); }
        //    set { SetValue(GameNameProperty, value); }
        //}
        
        //public static readonly DependencyProperty GameNameProperty =
        //    DependencyProperty.Register("GameName", typeof(string), typeof(GameItemControl), new PropertyMetadata("Game Name"));


        //public string GameBackgroundImage
        //{
        //    get { return (string)GetValue(GameBackgroundImageProperty); }
        //    set { SetValue(GameBackgroundImageProperty, value); }
        //}
        
        //public static readonly DependencyProperty GameBackgroundImageProperty =
        //    DependencyProperty.Register("GameBackgroundImage", typeof(string), typeof(GameItemControl), new PropertyMetadata(""));


        //public ICommand OpenGamePageCommand
        //{
        //    get { return (ICommand)GetValue(OpenGamePageCommandProperty); }
        //    set { SetValue(OpenGamePageCommandProperty, value); }
        //}
        
        //public static readonly DependencyProperty OpenGamePageCommandProperty =
        //    DependencyProperty.Register("OpenGamePageCommand", typeof(ICommand), typeof(GameItemControl));
        

        public GameItemControl(Game g)
        {
            InitializeComponent();

            DataContext = new GameItemViewModel(g);

            //GameName = name;
            //GameBackgroundImage = imagePath;
            //OpenGamePageCommand = new RelayCommand(() => MainContentViewModel.Instance.CurrentPage = new GamePage());
        }
    }
}
