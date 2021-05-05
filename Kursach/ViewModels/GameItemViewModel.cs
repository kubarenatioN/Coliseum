using Kursach.Views;

namespace Kursach
{
    public class GameItemViewModel : BaseViewModel
    {
        public MainContentViewModel MainContentInstance { get; set; }
        public Game ControlGame { get; set; }
        //public string GameName { get; set; }
        //public string GameBackgroundImage { get; set; }
        public RelayCommand OpenGamePageCommand { get; set; }

        public GameItemViewModel(Game g)
        {
            MainContentInstance = MainContentViewModel.Instance;
            ControlGame = g;
            OpenGamePageCommand = new RelayCommand(async () => await MainContentInstance.OpenPage(new GamePage(ControlGame)));
        }
    }
}
