using Kursach.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Kursach
{
    /// <summary>
    /// Custom Window View Model
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Fields

        /// <summary>
        /// Store Login Window
        /// </summary>
        private static Window _loginWindow;

        /// <summary>
        /// Outer margin around window to drop shadow + window border radius
        /// </summary>
        private int _outerMargin = 10;
        private int _borderRadius = 10;

        #endregion

        #region Public Properties

        /// <summary>
        /// Min width and height for window
        /// </summary>
        public double WindowMinWidth { get; set; } = 700;
        public double WindowMinHeight { get; set; } = 500;

        /// <summary>
        /// The value of resize border thickness
        /// </summary>
        public int ResizeBorder { get; set; } = 6;
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMargin); } }

        /// <summary>
        /// Return 0 outerMaring if window is fullscreen, otherwise return outerMargin
        /// </summary>
        public int OuterMargin
        {
            get
            {
                return _loginWindow.WindowState == WindowState.Maximized ? 0 : _outerMargin;
            }
            set { _outerMargin = value; }
        }
        /// <summary>
        /// Returns Thickness equals to OuterMargin value
        /// </summary>
        public Thickness OuterMarginThickness { get { return new Thickness(OuterMargin); } }

        /// <summary>
        /// Return 0 borderRadius if window is fullscreen, otherwise return normal borderRadius
        /// </summary>
        public int BorderRadius
        {
            get
            {
                return _loginWindow.WindowState == WindowState.Maximized ? 0 : _borderRadius;
            }
            set { _borderRadius = value; }
        }
        public CornerRadius BorderCornerRadius { get { return new CornerRadius(BorderRadius); } }

        /// <summary>
        /// The height of the window heading
        /// </summary>
        public int TitleHeight { get; set; } = 16;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public static Window LoginWindow { get { return _loginWindow; } }
        public static LoginViewModel Instance { get; set; }
        public Page CurrentPage { get; set; }

        /// <summary>
        /// History of pages navigation
        /// </summary>
        public Stack<Page> NavigationHistory { get; set; } = new Stack<Page>();

        #endregion

        #region Commands

        /// <summary>
        /// Minimize Window Command
        /// </summary>
        public RelayCommand MinimizeCommand { get; set; }

        /// <summary>
        /// Maximize Window Command
        /// </summary>
        public RelayCommand MaximizeCommand { get; set; }

        /// <summary>
        /// Close Window Command
        /// </summary>
        public RelayCommand CloseCommand { get; set; }

        #endregion

        public LoginViewModel(Window mainWindow)
        {
            Instance = this;

            _loginWindow = mainWindow;

            _loginWindow.StateChanged += (sender, e) =>
            {
                // Refresh properties on window resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                //OnPropertyChanged(nameof(OuterMargin));
                OnPropertyChanged(nameof(OuterMarginThickness));
                //OnPropertyChanged(nameof(BorderRadius));
                OnPropertyChanged(nameof(BorderCornerRadius));
            };

            // Initialize commands
            MinimizeCommand = new RelayCommand(() => _loginWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() =>
            {
                if (_loginWindow.WindowState == WindowState.Normal)
                {
                    _loginWindow.WindowState = WindowState.Maximized;
                }
                else _loginWindow.WindowState = WindowState.Normal;
            });
            CloseCommand = new RelayCommand(() => _loginWindow.Close());

            // Fix Window Resize Issue
            var resizer = new WindowResizer(_loginWindow);

            CurrentPage = new LoginWindowStartPage();
            NavigationHistory.Push(CurrentPage);

        }

        public async Task OpenPage(Page p)
        {
            double offset = CurrentPage.ActualWidth;

            await CurrentPage.PageAnimationSlideFadeOutToLeft(0.3f);

            // Change Current Page
            CurrentPage = p;

            await CurrentPage.PageAnimationSlideFadeInFromRight(0.3f, offset);
            
            // Add new page to history
            NavigationHistory.Push(CurrentPage);
        }

        public async Task GoBack()
        {
            double offset = CurrentPage.ActualWidth;
            await CurrentPage.PageAnimationSlideFadeOutToRight(0.3f);
            
            // remove current page from stack;
            NavigationHistory.Pop();
            
            // return prev page to display
            CurrentPage = NavigationHistory.Peek();

            await CurrentPage.PageAnimationSlideFadeInFromLeft(0.3f, offset);
        }
    }
}
