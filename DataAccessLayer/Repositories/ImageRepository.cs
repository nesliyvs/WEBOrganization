using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ImageRepository:RepositoryBase<Image>
    {
        public ImageRepository(OrganizationDbEntities ctx):base(ctx)
        {

        }
    }
}
