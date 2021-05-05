using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kursach
{
    public class UserPublicInfo
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Country { get; set; }
        
        public virtual User User { get; set; }
        public virtual ICollection<UsersGames> UsersGames { get; set; }
        //public virtual ICollection<Friendship> UserFriendWith { get; set; } // my friends
        //public virtual ICollection<Friendship> UserFriendTo { get; set; } // users i friend for

        //public UserPublicInfo() { }
    }
}
