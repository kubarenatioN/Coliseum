using System.Collections.Generic;

namespace Kursach
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public virtual UserPublicInfo UserPublicInfo { get; set; }
        public virtual UserAccountInfo UserAccountInfo { get; set; }

        //public ICollection<Friendship> Friendships { get; set; }
        public virtual ICollection<Friendship> UserFriendWith { get; set; } // my friends
        public virtual ICollection<Friendship> UserFriendTo { get; set; } // users i friend for

        public User()
        {
            UserPublicInfo = new UserPublicInfo();
            UserAccountInfo = new UserAccountInfo();
        }
    }
}
