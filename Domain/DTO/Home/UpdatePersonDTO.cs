using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Home
{
    public class UpdatePersonDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "ورود نام اجباری است بی شرف")]
        public string Name { get; set; }
    }
}
