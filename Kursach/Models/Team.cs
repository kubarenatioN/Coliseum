using System;
using System.Collections.Generic;

namespace Kursach
{
    public class Team
    {
        public int Id { get; set; }
        public string BannerImage { get; set; }
        public int PrizeAccount { get; set; }
        public DateTime? FoundationDate { get; set; }

        public virtual Game Game { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<EventsTeams> EventsTeams { get; set; }


        public override string ToString()
        {
            return $"{Id}: {Organization.FullName} - {Game.Name}; {FoundationDate}";
        }
    }
}
