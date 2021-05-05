using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Kursach
{
    public class EventsRepository : Repository<Event>
    {
        public DbContext EventsContext;
        public EventsRepository(DbContext context) : base(context)
        {
            EventsContext = context;
        }

        public List<Event> FindEventsWithGames(Expression<Func<Event, bool>> predicate)
        {
            List<Event> entities = EventsContext.Set<Event>().Where(predicate).Include(evnt => evnt.EventGame).ToList();

            return entities;
        }
    }
}
