using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Security
{
    public class PermisionDTO
    {
        public List<PermisionInfoDTO> Permisions { get; set; } = new List<PermisionInfoDTO>();
        public long RoleId { get; set; }
    }

    public class PermisionInfoDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
