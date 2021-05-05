using System.Collections.Generic;

namespace Kursach
{
    public class EventsViewModel : BaseViewModel
    {
        public List<EventItemControl> EventsCollection { get; set; }

        public EventsViewModel()
        {
            EventsCollection = new List<EventItemControl>();
            GenerateEventItems();
        }

        private void GenerateEventItems()
        {
            List<Event> events = UnitOfWork.Events.GetAll();
            foreach (Event e in events)
            {
                EventsCollection.Add(new EventItemControl(e));
            }
        }
    }
}
