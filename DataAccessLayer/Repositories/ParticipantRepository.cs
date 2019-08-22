using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ParticipantRepository:RepositoryBase<Participant>,IParticipantRepository
    {
        public ParticipantRepository(OrganizationDbEntities ctx):base(ctx)
        {

        }
    }
}
