using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models.Security
{
    public class Menu
    {
        public Menu()
        {
            this.Children = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string Denomination { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Iamge { get; set; }
        public string Description { get; set; }

        public int ModuleId { get; set; }
        public int? ParentId { get; set; }

        public virtual Module Module { get; set; }
        public virtual Menu Parent { get; set; }

        public virtual ICollection<Menu> Children { get; set; }
    }
}
