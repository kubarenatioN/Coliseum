using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kursach
{
    public class OrganizationsRepository : Repository<Organization>, IOrganizationsRepository
    {
        public OrganizationsRepository(DbContext context) : base(context)
        {
        }

        public async Task<List<Organization>> GetAllWithTeams()
        {
            List<Organization> orgsWithTeams = await Context.Set<Organization>().Include(org => org.Teams).ToListAsync();

            return orgsWithTeams;
        }
    }
}
