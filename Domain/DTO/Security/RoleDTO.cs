using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Security
{
    public class RoleDTO
    {
        public List<RoleInfoDTO> Roles { get; set; } = new List<RoleInfoDTO>();
        public List<ActionItem> Actions { get; set; } = new List<ActionItem>();
    }

    public class RoleInfoDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
