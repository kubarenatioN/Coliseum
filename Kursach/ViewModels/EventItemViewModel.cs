using Kursach.Views;
using System;

namespace Kursach
{
    public class EventItemViewModel : BaseViewModel
    {
        public Event Event { get; set; }
        public string StartDate { get; set; }
        public RelayCommand OpenEventPageCommand { get; set; }
        public EventItemViewModel(Event e)
        {
            Event = e;
            StartDate = Event.StartDate.Value.ToShortDateString();

            OpenEventPageCommand = new RelayCommand(async () => await MainContentViewModel.Instance.OpenPage(new EventPage(Event)));
        }
    }
}
