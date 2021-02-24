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
        private Window _mainWindow;

        /// <summary>
        /// Outer margin around window to drop shadow + window border radius
        /// </summary>
        private int _outerMargin = 10;
        private int _borderRadius = 10;

        #endregion

        #region Public Properties

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
        public int TitleHeight { get; set; } = 20;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }


        #endregion

        #region Commands

        /// <summary>
        /// Minimize Window Command
        /// </summary>
        public RelayCommand MinimizeCommand;

        /// <summary>
        /// Maximize Window Command
        /// </summary>
        public RelayCommand MaximizeCommand;

        /// <summary>
        /// Close Window Command
        /// </summary>
        public RelayCommand CloseCommand;

        /// <summary>
        /// Open Window Menu Command
        /// </summary>
        public RelayCommand MenuCommand;

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
                else return;
            });
            CloseCommand = new RelayCommand(() => _mainWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_mainWindow, Mouse.GetPosition(_mainWindow)));
        }
    }
}
