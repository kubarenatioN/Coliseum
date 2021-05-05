using System.Collections.Generic;

namespace Kursach
{
    public class TeamPageViewModel : BaseViewModel
    {
        public MainContentViewModel MainContentInstance { get; set; }
        /// <summary>
        /// Add Players Filed to the Team class
        /// </summary>
        public Team Team { get; set; }
        public List<PlayerItemControl> Players { get; set; } = new List<PlayerItemControl>();
        public RelayCommand GoBackCommand { get; set; }
        public TeamPageViewModel(Team team)
        {
            MainContentInstance = MainContentViewModel.Instance;

            Team = team;
            // Get Players collection from the team object here
            foreach (Player p in Team.Players)
            {
                Players.Add(new PlayerItemControl(p));
            }

            GoBackCommand = new RelayCommand(async () => await MainContentInstance.GoBack());

        }
    }
}
