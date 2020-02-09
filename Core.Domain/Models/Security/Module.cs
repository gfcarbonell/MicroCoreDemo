using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models.Security
{
    public class Module
    {
        public int Id { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }
        public int SystemId { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
    }
}
