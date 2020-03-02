using Core.Domain.Models.Generic;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.Domain.Models
{
    public class System 
    {
        public int Id { get; set; }
        public string Denomination { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
