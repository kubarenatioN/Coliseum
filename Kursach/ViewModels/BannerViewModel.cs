using Kursach.Views;
using System.Windows;
using System.Windows.Controls;

namespace Kursach
{
    public class BannerViewModel : BaseViewModel
    {
        //Id of referencing event page
        public int EventId { get; set; }
        
        public RelayCommand OpenBannerPageCommand { get; set; }
        public MainContentViewModel MainContentInstance { get; set; }

        public string BannerTitle { get; set; } = "Event Title Here";

        public BannerViewModel()
        {
            MainContentInstance = MainContentViewModel.Instance;

            OpenBannerPageCommand = new RelayCommand(async () => await MainContentInstance.OpenPage(new GamesPage()));

        }
    }
}
