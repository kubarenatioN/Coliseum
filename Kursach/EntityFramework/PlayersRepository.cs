using Microsoft.EntityFrameworkCore;

namespace Kursach
{
    public class PlayersRepository : Repository<Player>
    {
        public PlayersRepository(ColiseumDbContext context) : base(context)
        {
        }
    }
}
