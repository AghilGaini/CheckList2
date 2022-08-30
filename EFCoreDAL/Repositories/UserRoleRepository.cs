using Domain.DTO.Security;
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
    public class UserRoleRepository : GenericRepository<UserRoleDomain>, IUserRoleDomain
    {
        private readonly ApplicationContext _context;

        public UserRoleRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> DeleteRolesByUserIdAsync(long userId)
        {
            try
            {
                var res = await _context.UserRoles.Where(r => r.UserId == userId).ToListAsync();

                _context.UserRoles.RemoveRange(res);

                return true;

            }
            catch
            {
                return false;
            }

        }

        public async Task<IEnumerable<long>> GetAllRolesIdByUserIDAsync(long userId)
        {
            return await _context.UserRoles.Where(r => r.UserId == userId).Select(r => r.RoleId).ToListAsync();
        }

        public async Task<bool> InsertUserRoleDTOAsync(UserRoleDTO model)
        {
            try
            {
                var newUserRoles = new List<UserRoleDomain>();

                foreach (var item in model.Roles)
                {
                    newUserRoles.Add(new UserRoleDomain()
                    {
                        RoleId = item.Id,
                        UserId = model.UserId
                    });
                }

                await _context.UserRoles.AddRangeAsync(newUserRoles);

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
