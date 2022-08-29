using Domain.Entities;
using Domain.Interfaces;
using EFCoreDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDAL.Repositories
{
    public class RoleRepository : GenericRepository<RoleDomain>, IRoleDomain
    {
        public RoleRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
