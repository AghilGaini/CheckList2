using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ActionItem
    {
        public string Title { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Route { get; set; }
    }
}
