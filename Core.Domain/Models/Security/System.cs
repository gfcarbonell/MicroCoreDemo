using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models.Security
{
    public class System
    {
        public int Id { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Module> Menu { get; set; }
    }
}
