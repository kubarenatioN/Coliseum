using Kursach.Controls;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Kursach
{
    public class TeamsViewModel : BaseViewModel
    {
        public List<TeamItemControl> TeamsCollection { get; set; } = new List<TeamItemControl>();
        public TeamsViewModel()
        {
            foreach (Team team in Repository<Team>.context.Set<Team>().Include(t => t.Organization).Include(t => t.Game).Include(t => t.Players))
            {
                TeamsCollection.Add(new TeamItemControl(team));
            }
        }
    }
}
