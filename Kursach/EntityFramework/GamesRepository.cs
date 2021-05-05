using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Kursach
{
    public class GamesRepository : Repository<Game>
    {
        public GamesRepository(ColiseumDbContext context) : base(context) { }

        public List<Game> GetAllGamesWithImages(Expression<Func<Game, bool>> predicate)
        {
            List<Game> gamesWithImages = Context.Set<Game>().Include(game => game.GameImage).Where(predicate).ToList();

            return gamesWithImages;
        }
    }
}
