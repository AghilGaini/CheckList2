using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Home
{
    public class PersonDTO
    {
        public List<ActionItem> Actions { get; set; } = new List<ActionItem>();
        public List<PersonInfoDTO> PersonInfos { get; set; } = new List<PersonInfoDTO>();
    }

    public class PersonInfoDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
