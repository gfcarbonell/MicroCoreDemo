using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models.Security
{
    public class Permission
    {
        public Permission()
        {
            this.PermissionRoles = new HashSet<PermissionRole>();
        }

        public int Id { get; set; }
        public string Denomination { get; set; }
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
