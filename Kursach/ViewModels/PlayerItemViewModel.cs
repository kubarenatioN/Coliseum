using Kursach.Views;
using System.Windows;

namespace Kursach
{
    public class PlayerItemViewModel : BaseViewModel
    {
        public MainContentViewModel MainContentInstance { get; set; }
        public Player Player { get; set; }
        public RelayCommand TestCommand { get; set; }

        public PlayerItemViewModel(Player p)
        {
            MainContentInstance = MainContentViewModel.Instance;
            Player = p;

            TestCommand = new RelayCommand(async () => await MainContentInstance.OpenPage(new PlayerPage(p)));
        }
    }
}
