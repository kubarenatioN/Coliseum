using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kursach
{
    public class UsersGames
    {
        public int Id { get; set; }
        
        [ForeignKey("UserPublicInfo")]
        public int UserPublicInfoId { get; set; }
        
        [ForeignKey("Game")]
        public int GameId { get; set; }

        public virtual UserPublicInfo User { get; set; }
        public virtual Game Game { get; set; }
    }
}
