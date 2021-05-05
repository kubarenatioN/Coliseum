using Kursach.Views;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Kursach
{
    public class GamePageViewModel : BaseViewModel
    {
        public MainContentViewModel MainContentInstance { get; set; }
        public Game PageGame { get; set; }
        public RelayCommand GoBackCommand { get; set; }

        public GamePageViewModel(Game game)
        {
            MainContentInstance = MainContentViewModel.Instance;
            PageGame = game;
            
            GoBackCommand = new RelayCommand(async () => await MainContentInstance.GoBack());
        }
    }
}
