using System.Windows;
using System.Windows.Input;

namespace Kursach
{
    /// <summary>
    /// Custom Window View Model
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Fields

        /// <summary>
        /// Store Main Form Window
        /// </summary>
        private static Window _mainWindow;

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
        public double WindowMinWidth { get; set; } = 1200;
        public double WindowMinHeight { get; set; } = 700;

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
                return _mainWindow.WindowState == WindowState.Maximized ? 0 : _outerMargin;
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
                return _mainWindow.WindowState == WindowState.Maximized ? 0 : _borderRadius;
            }
            set { _borderRadius = value; }
        }
        public CornerRadius BorderCornerRadius { get { return new CornerRadius(BorderRadius); } }

        /// <summary>
        /// The height of the window heading
        /// </summary>
        public int TitleHeight { get; set; } = 16;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public static Window MainWindow
        {
            get { return _mainWindow; }
        }

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

        /// <summary>
        /// Open Window Menu Command
        /// </summary>
        public RelayCommand MenuCommand { get; set; }

        #endregion

        public WindowViewModel(Window mainWindow)
        {
            _mainWindow = mainWindow;

            _mainWindow.StateChanged += (sender, e) =>
            {
                // Refresh properties on window resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                //OnPropertyChanged(nameof(OuterMargin));
                OnPropertyChanged(nameof(OuterMarginThickness));
                //OnPropertyChanged(nameof(BorderRadius));
                OnPropertyChanged(nameof(BorderCornerRadius));
            };

            // Initialize commands
            MinimizeCommand = new RelayCommand(() => _mainWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() =>
            {
                if (_mainWindow.WindowState == WindowState.Normal)
                {
                    _mainWindow.WindowState = WindowState.Maximized;
                }
                else _mainWindow.WindowState = WindowState.Normal;
            });
            CloseCommand = new RelayCommand(() => _mainWindow.Close());

            // Fix Window Resize Issue
            var resizer = new WindowResizer(_mainWindow);
        }
    }
}
