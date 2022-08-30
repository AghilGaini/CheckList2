using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Security
{
    public class UserRoleDTO
    {
        public List<RoleInfoDTO> Roles { get; set; } = new List<RoleInfoDTO>();
        public long UserId { get; set; }
    }

}
