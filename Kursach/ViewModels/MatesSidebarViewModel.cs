using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Kursach
{
    public class MatesSidebarViewModel : BaseViewModel
    {
        private string usersSearchQuery;
        public string UsersSearchQuery
        {
            get { return usersSearchQuery; }
            set
            {
                if (usersSearchQuery == value) return;
                usersSearchQuery = value;
                OnPropertyChanged(nameof(UsersSearchQuery));
                SearchUsers();
            }
        }
        public User User { get; set; }
        public string PublicData { get; set; }
        public List<FriendControl> UserFriendItems { get; set; }
        public List<User> Users { get; set; }
        public List<FriendControl> SearchedUsers { get; set; }

        public MatesSidebarViewModel(User user)
        {
            // get current user Id
            //int userId = Properties.Settings.Default.LoggedUserId;
            User = user;

            PublicData = user.UserPublicInfo.Name;

            UserFriendItems = new List<FriendControl>();
            foreach (Friendship f in user.UserFriendWith)
            {
                UserFriendItems.Add(new FriendControl(f.Friend));
            }

            SearchedUsers = new List<FriendControl>();
            Users = UnitOfWork.Users.GetAll();     
        }

        public void SearchUsers()
        {
            List<FriendControl> res = new List<FriendControl>();
            foreach (User u in Users)
            {
                if (u.UserPublicInfo.Nickname.SubstringOrFull(UsersSearchQuery.Length) == UsersSearchQuery &&
                    u.Id != User.Id)
                {
                    res.Add(new FriendControl(u));
                }
            }
            SearchedUsers = res;
        }
    }
}
