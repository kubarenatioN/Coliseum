using System.Collections.Generic;

namespace Kursach
{
    public interface ITeamsRepository : IRepository<Team>
    {
        IEnumerable<Team> GetAllWithOrganizations();
    }
}
