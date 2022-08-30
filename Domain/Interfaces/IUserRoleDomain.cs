using Domain.DTO.Security;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRoleDomain : IGenericDomain<UserRoleDomain>
    {
        Task<IEnumerable<long>> GetAllRolesIdByUserIDAsync(long userId);
        Task<bool> DeleteRolesByUserIdAsync(long userId);
        Task<bool> InsertUserRoleDTOAsync(UserRoleDTO model);
    }
}
