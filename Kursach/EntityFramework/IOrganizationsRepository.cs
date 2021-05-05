using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kursach
{
    public interface IOrganizationsRepository : IRepository<Organization>
    {
        Task<List<Organization>> GetAllWithTeams();
    }
}
