using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для BannerControl.xaml
    /// </summary>
    public partial class BannerControl : UserControl
    {
        public ImageSource BannerImageSource
        {
            get { return (ImageSource)GetValue(BannerImageSourceProperty); }
            set { SetValue(BannerImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BannerImageSourceProperty =
            DependencyProperty.Register("BannerImageSource", typeof(ImageSource), typeof(BannerControl), new PropertyMetadata());



        public TextAlignment ContentAlignment
        {
            get { return (TextAlignment)GetValue(ContentAlignmentProperty); }
            set { SetValue(ContentAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentAlignmentProperty =
            DependencyProperty.Register("ContentAlignment", typeof(TextAlignment), typeof(BannerControl), new PropertyMetadata(TextAlignment.Left));


        public AlignmentY BannerImageAlignmentY
        {
            get { return (AlignmentY)GetValue(BannerImageAlignmentYProperty); }
            set { SetValue(BannerImageAlignmentYProperty, value); }
        }
        
        public static readonly DependencyProperty BannerImageAlignmentYProperty =
            DependencyProperty.Register("BannerImageAlignmentY", typeof(AlignmentY), typeof(BannerControl), new PropertyMetadata(AlignmentY.Center));



        public string BannerTitle
        {
            get { return (string)GetValue(BannerTitleProperty); }
            set { SetValue(BannerTitleProperty, value); }
        }
        
        public static readonly DependencyProperty BannerTitleProperty =
            DependencyProperty.Register("BannerTitle", typeof(string), typeof(BannerControl), new PropertyMetadata(""));



        public string BannerSubtitle
        {
            get { return (string)GetValue(BannerSubtitleProperty); }
            set { SetValue(BannerSubtitleProperty, value); }
        }
        
        public static readonly DependencyProperty BannerSubtitleProperty =
            DependencyProperty.Register("BannerSubtitle", typeof(string), typeof(BannerControl), new PropertyMetadata(""));




        public RelayCommand OpenPageCommand
        {
            get { return (RelayCommand)GetValue(OpenPageCommandProperty); }
            set { SetValue(OpenPageCommandProperty, value); }
        }

        public static readonly DependencyProperty OpenPageCommandProperty =
            DependencyProperty.Register("OpenPageCommand", typeof(RelayCommand), typeof(BannerControl), new PropertyMetadata(null));



        public BannerControl()
        {
            InitializeComponent();
        }
    }
}
