using System;
using System.Collections.Generic;

namespace Kursach
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double PrizePool { get; set; }
        public string Location { get; set; }
        public string EventItemImage { get; set; }
        public string EventBannerImage { get; set; }
        public int GameId { get; set; }

        public virtual Game EventGame { get; set; }
        public virtual ICollection<EventsTeams> EventsTeams { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Title}; Game: {EventGame.Name}";
        }
    }
}
