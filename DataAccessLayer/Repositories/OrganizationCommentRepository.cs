using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrganizationCommentRepository:RepositoryBase<OrganizationComment>
    {
        public OrganizationCommentRepository(OrganizationDbEntities ctx):base(ctx)
        {

        }
    }
}
