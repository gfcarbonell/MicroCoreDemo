using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class Role
    {
        public Role()
        {
            this.UserRoles = new List<UserRole>();
            this.PermissionRoles = new List<PermissionRole>();
        }

        public int Id { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
