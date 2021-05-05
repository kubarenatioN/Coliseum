using System.ComponentModel.DataAnnotations.Schema;

namespace Kursach
{
    public class EventsTeams
    {
        public int Id { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Team Team { get; set; }
    }
}
