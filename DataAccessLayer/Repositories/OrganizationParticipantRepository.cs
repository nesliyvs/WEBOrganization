using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrganizationParticipantRepository:RepositoryBase<OrganizationParticipant>
    {
        public OrganizationParticipantRepository(OrganizationDbEntities ctx):base(ctx)
        {

        }
    }
}
