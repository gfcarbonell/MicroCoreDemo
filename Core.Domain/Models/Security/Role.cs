using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models.Security
{
    public class Role
    {
        public Role()
        {
            this.UserRoles = new HashSet<UserRole>();
            this.PermissionRoles = new HashSet<PermissionRole>();
        }

        public int Id { get; set; }
        public string Denomination { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
