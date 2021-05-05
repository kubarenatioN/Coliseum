using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kursach
{
    public interface IEventsRepository : IRepository<Event>
    {
        List<Event> FindEventsWithGames(Expression<Func<Event, bool>> predicate);
    }
}
