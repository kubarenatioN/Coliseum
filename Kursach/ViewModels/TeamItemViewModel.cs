using Kursach.Views;

namespace Kursach
{
    public class TeamItemViewModel
    {
        public MainContentViewModel MainContentInstance { get; set; }
        public RelayCommand OpenTeamPageCommand { get; set; }
        public Team Team { get; set; }
        public TeamItemViewModel(Team team)
        {
            Team = team;

            MainContentInstance = MainContentViewModel.Instance;

            OpenTeamPageCommand = new RelayCommand(async () => await MainContentInstance.OpenPage(new TeamPage(Team)));
        }
    }
}
