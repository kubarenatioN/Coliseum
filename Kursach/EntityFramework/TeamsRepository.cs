using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kursach
{
    public class TeamsRepository : Repository<Team>, ITeamsRepository
    {
        public DbContext TeamsContext;
        public TeamsRepository(DbContext context) : base(context)
        {
            TeamsContext = context;
        }

        public IEnumerable<Team> GetAllWithOrganizations()
        {
            IEnumerable<Team> teams = Context.Set<Team>().Include(t => t.Organization);
            return teams;
        }
    }
}
