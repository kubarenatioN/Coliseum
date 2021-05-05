using System.Collections.Generic;
using System.Linq;

namespace Kursach
{
    public class EventPageViewModel
    {
        public Event Event { get; set; }
        public List<TeamItemSquareControl> Teams { get; set; }
        public RelayCommand GoBackCommand { get; set; }
        public EventPageViewModel(Event e)
        {
            Event = e;

            GoBackCommand = new RelayCommand(async () => await MainContentViewModel.Instance.GoBack());

            Teams = new List<TeamItemSquareControl>();
            GenerateTeams();
        }

        private void GenerateTeams()
        {
            List<Team> teams = UnitOfWork.EventsTeams.Get(et => et.EventId == Event.Id).Select(et => et.Team).ToList();
            foreach (Team team in teams)
            {
                Teams.Add(new TeamItemSquareControl(team));
            }
        }
    }
}
