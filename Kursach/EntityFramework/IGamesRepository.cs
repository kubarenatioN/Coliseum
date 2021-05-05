using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kursach
{
    public interface IGamesRepository : IRepository<Game>
    {
        List<Game> GetAllGamesWithImages(Expression<Func<Game, bool>> predicate);
    }
}
