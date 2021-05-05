using Kursach.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Kursach
{
    public class HomeViewModel : BaseViewModel
    {
        public RelayCommand LoadFromDB { get; set; }
        public RelayCommand TestColor { get; set; }
        public List<Team> TestCollection { get; set; }
        public List<Player> TestCollection2 { get; set; }
        public List<Game> GamesInitialCollection { get; set; }
        public List<Event> EventsInitialCollection { get; set; }

        public RelayCommand MainBannerOpenPage { get; set; }

        public string TextBlock1Text { get; set; } = "Some Text Inside TextBlock";

        public HomeViewModel()
        {
            TestColor = new RelayCommand(() =>
            {
                
                string curColorsFileName = Application.Current.Resources.MergedDictionaries.FirstOrDefault(rd => rd.Source == new Uri("Styles/Colors.xaml", UriKind.Relative)) != null ? "" : "-light";
                string newColorsFileName = Application.Current.Resources.MergedDictionaries.FirstOrDefault(rd => rd.Source == new Uri("Styles/Colors.xaml", UriKind.Relative)) == null ? "" : "-light";
                //Console.WriteLine(curColorsFileName);
                ResourceDictionary currentColors = Application.Current.Resources.MergedDictionaries.FirstOrDefault(rd => rd.Source == new Uri($"Styles/Colors{curColorsFileName}.xaml", UriKind.Relative));
                ResourceDictionary newColors = new ResourceDictionary()
                {
                    Source = new Uri($"Styles/Colors{newColorsFileName}.xaml", UriKind.Relative)
                };

                //Console.WriteLine(currentColors.Values);
                int dictPosition = Application.Current.Resources.MergedDictionaries.IndexOf(currentColors);
                //Console.WriteLine(dictPosition);

                Application.Current.Resources.MergedDictionaries.Remove(currentColors);
                Application.Current.Resources.MergedDictionaries.Insert(dictPosition, newColors);
            });

            LoadFromDB = new RelayCommand(() => {

                // include navigation props using typed methods
                IEnumerable<Team> teams = UnitOfWork.Teams.GetAll();
                TestCollection = teams.ToList();

                // explicit including navigation properties
                //IEnumerable<Player> players = Repository<Player>.context.Set<Player>().Include(p => p.Team).Include(p => p.Game);
                IEnumerable<Player> players = UnitOfWork.Players.GetAll();
                TestCollection2 = players.ToList();

                TextBlock1Text = "hello";
            });

            GamesInitialCollection = UnitOfWork.Games.Get(game => game.Id > 0 && game.Id < 10);

            EventsInitialCollection = UnitOfWork.Events.GetAll();

            MainBannerOpenPage = new RelayCommand(async () => await MainContentViewModel.Instance.OpenPage(new GamesPage()));

        }
    }
}
