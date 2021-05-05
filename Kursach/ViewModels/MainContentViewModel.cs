using Kursach.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursach
{
    public class MainContentViewModel : BaseViewModel
    {
        #region Public Fields
        
        /// <summary>
        /// static Instance of this single object to get access by other viewmodels to CurrentPage and etc
        /// </summary>
        public static MainContentViewModel Instance { get; set; }

        /// <summary>
        /// History of pages navigation
        /// </summary>
        public Stack<Page> NavigationHistory { get; set; } = new Stack<Page>();

        /// <summary>
        /// Store currently active page
        /// </summary>
        public Page CurrentPage { get; set; }

        /// <summary>
        /// Logined user object
        /// </summary>
        public User User { get; set; }  

        #endregion

        #region Commands

        public RelayCommand OpenHomePage { get; set; }
        public RelayCommand OpenGamesPage { get; set; }
        public RelayCommand OpenNewsPage { get; set; }
        public RelayCommand OpenEventsPage { get; set; }
        public RelayCommand OpenTeamsPage { get; set; }

        public RelayCommand OpenFriendPage { get; set; }

        #endregion

        public MainContentViewModel(WindowHeaderControl header, MatesSidebarControl sidebar)
        {
            // set this object to be the main app instance
            Instance = this;

            // set current page
            CurrentPage = new HomePage();

            // add page to the navigation history
            NavigationHistory.Push(CurrentPage);

            // get logined user data
            int userId = Properties.Settings.Default.LoggedUserId;
            User = UnitOfWork.Users.GetById(userId);

            header.DataContext = new WindowHeaderViewModel(User);
            sidebar.DataContext = new MatesSidebarViewModel(User);

            OpenHomePage = new RelayCommand(async () => await OpenPage(new HomePage()));
            OpenGamesPage = new RelayCommand(async () => await OpenPage(new GamesPage()));
            OpenNewsPage = new RelayCommand(async () => await OpenPage(new NewsPage()));
            OpenEventsPage = new RelayCommand(async () => await OpenPage(new EventsPage()));
            OpenTeamsPage = new RelayCommand(async () => await OpenPage(new TeamsPage()));
        }

        /// <summary>
        /// Method to perform page animations and open another page
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task OpenPage(Page p)
        {
            // If we try to open currently active page, just open it with no animations
            //if (p.GetType() == CurrentPage.GetType())
            //{
            //    CurrentPage = p;
            //}
            // if we open user's page and active page is also user's page
            if (p.GetType() == typeof(UserPage) 
                && CurrentPage.GetType() == typeof(UserPage) 
                // if we open page of the same user
                && ((p as UserPage).DataContext as UserPageViewModel).User == ((CurrentPage as UserPage).DataContext as UserPageViewModel).User)
            {
                return;
            }
            // if we open the same page, but not the user's page
            else if (p.GetType() == CurrentPage.GetType() && p.GetType() != typeof(UserPage))
            {
                return;
            }
            // else open another page with animation
            else
            {
                // Get frame width to pass it inside animation methods
                double offset = CurrentPage.ActualWidth;

                // fade out old page
                await CurrentPage.PageAnimationShortSlideFadeOutToLeft(0.24f, 20);

                // set new page
                CurrentPage = p;

                // fade in new page
                await CurrentPage.PageAnimationShortSlideFadeInFromLeft(0.24f, 20);

                // Add new page to history
                NavigationHistory.Push(CurrentPage);
            }
        }

        public async Task GoBack()
        {
            double offset = CurrentPage.ActualWidth;

            await CurrentPage.PageAnimationShortSlideFadeOutToLeft(0.3f, 50);

            // remove current page from stack;
            NavigationHistory.Pop();
            // return prev page to display it
            CurrentPage = NavigationHistory.Peek();

            await CurrentPage.PageAnimationShortSlideFadeInFromLeft(0.3f, 50);
        }

        /// <summary>
        /// Command parameter which signs can we open page 
        /// ######################### ARCHIVED, NOT IN USE NOW, JUST COOL APPROACH FOR ME
        /// </summary>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        private bool CanOpenPage(object isChecked)
        {
            //Console.WriteLine(!(bool)isChecked);

            //If page is not checked, we can open it
            return !(bool)isChecked;
        }
    }
}
