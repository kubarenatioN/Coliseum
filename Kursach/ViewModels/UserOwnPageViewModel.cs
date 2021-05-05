using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Kursach
{
    public class UserOwnPageViewModel : BaseViewModel
    {
        private MainContentViewModel mainViewModel;
        private Window mainWindow;
        private readonly double contentMaxWidth = 1400;

        public User User { get; set; }
        public string UserBannerImage { get; set; }
        public string Nickname { get; set; }
        public List<GameItemControl> UserGameItems { get; set; }
        public double PaddingLeft { get; set; }
        public Visibility GamesVisibility { get; set; }
        public Visibility NoGamesSignVisibility { get; set; }

        public UserOwnPageViewModel()
        {
            mainViewModel = MainContentViewModel.Instance;

            mainWindow = WindowViewModel.MainWindow;

            // set page's user
            User = mainViewModel.User;

            // Load user's info
            UserBannerImage = User.UserAccountInfo.BannerImage;
            Nickname = User.UserPublicInfo.Nickname;

            LoadUsersGames();
            EnablePaddingCheck();
            CheckGamesCount();
        }

        /// <summary>
        /// Check if user has games
        /// </summary>
        private void CheckGamesCount()
        {
            if(UserGameItems.Count == 0)
            {
                GamesVisibility = Visibility.Collapsed;
                NoGamesSignVisibility = Visibility.Visible;
            }
            else
            {
                GamesVisibility = Visibility.Visible;
                NoGamesSignVisibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Set up all User's game items
        /// </summary>
        private void LoadUsersGames()
        {
            // selecting this user's games
            List<Game> userGames = UnitOfWork.UsersGames.Get(ug => ug.UserPublicInfoId == User.Id).Select(ug => ug.Game).ToList();

            // load each game's images data
            foreach (Game game in userGames)
            {
                Repository<Game>.context.Entry(game).Reference("GameImage").Load();
            }

            // convert general Game objects into GameItemControls
            UserGameItems = new List<GameItemControl>();
            foreach (Game game in userGames)
            {
                UserGameItems.Add(new GameItemControl(game));
            }
        }

        /// <summary>
        /// Listen to Window change width
        /// </summary>
        private void EnablePaddingCheck()
        {
            SetPadding();
            mainWindow.SizeChanged += (sender, e) =>
            {
                SetPadding();
            };
        }

        /// <summary>
        /// Set new padding value
        /// </summary>
        private void SetPadding()
        {
            double windowWidth = mainWindow.ActualWidth;
            if (windowWidth > contentMaxWidth)
            {
                PaddingLeft = windowWidth - contentMaxWidth;
            }
            else
            {
                PaddingLeft = 0;
            }
        }
    }
}
