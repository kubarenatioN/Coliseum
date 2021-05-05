namespace Kursach
{
    public class PlayerPageViewModel : BaseViewModel
    {
        public MainContentViewModel MainContentInstance { get; set; }
        public Player Player { get; set; }
        public RelayCommand GoBackCommand { get; set; }

        public PlayerPageViewModel(Player p)
        {
            MainContentInstance = MainContentViewModel.Instance;

            Player = p;

            GoBackCommand = new RelayCommand(async () => await MainContentInstance.GoBack());

        }
    }
}
