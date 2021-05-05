using Kursach.Views;

namespace Kursach
{
    public class TeamItemSquareViewModel : BaseViewModel
    {
        public Team Team { get; set; }
        public string OrganizationLogo { get; set; }
        public string TeamName { get; set; }
        public RelayCommand OpenTeamPageCommand { get; set; }
        public TeamItemSquareViewModel(Team t)
        {
            Team = t;
            OrganizationLogo = Team.Organization.OrganizationLogo;
            TeamName = Team.Organization.ShortName;

            OpenTeamPageCommand = new RelayCommand(async() => await MainContentViewModel.Instance.OpenPage(new TeamPage(Team)));
        }
    }
}
