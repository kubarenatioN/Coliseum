using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kursach
{
    public class GameImages
    {
        [Key]
        public int Id { get; set; }
        public string GameItemImageName { get; set; }
        public string GamePageImageName { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; } // one-to-one relationship
        public virtual Game Game { get; set; }
    }
}
