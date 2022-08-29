using Domain.Entities;
using Domain.Interfaces;
using EFCoreDAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDAL.Repositories
{
    public class RolePermisionRepository : GenericRepository<RolePermisionDomain>, IRolePermisionDomain
    {
        private readonly ApplicationContext _context;

        public RolePermisionRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<long>> GetAllPermisionsIdByRoleIDAsync(long roleId)
        {
            return await _context.RolePermisions.Where(r => r.RoleId == roleId).Select(r => r.PermisionId).ToListAsync();
        }
    }
}
