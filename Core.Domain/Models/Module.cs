using Core.Domain.Models.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class Module 
    {
        public int Id { get; set; }
        public int SystemId { get; set; }
        public string Denomination { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public System System { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
