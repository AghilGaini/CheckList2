using Domain.DTO.Security;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRolePermisionDomain : IGenericDomain<RolePermisionDomain>
    {
        Task<IEnumerable<long>> GetAllPermisionsIdByRoleIDAsync(long roleId);
        Task<bool> DeletePermisionsByRoleIdAsync(long roleId);
        Task<bool> InsertRolePermisionDTOAsync(PermisionDTO model);


    }
}
