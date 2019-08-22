using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrgImageRepository:RepositoryBase<OrganizationImage>,IOrgImageRepository
    {
        public OrgImageRepository(OrganizationDbEntities ctx):base(ctx)
        {

        }
    }
}
