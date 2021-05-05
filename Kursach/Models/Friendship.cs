using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kursach
{
    public class Friendship
    {
        //public int Id { get; set; }

        //[Key, Column(Order = 0)]
        //[ForeignKey("UserPublicInfo")]
        public int UserId { get; set; }
        
        //[Key, Column(Order = 1)]
        //[ForeignKey("UserPublicInfo")]
        public int FriendId { get; set; }

        public virtual User User { get; set; }
        public virtual User Friend { get; set; }
    }
}
