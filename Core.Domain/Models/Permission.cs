using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class Permission
    {
        public Permission()
        {
            this.PermissionRoles = new List<PermissionRole>();
        }

        public int Id { get; set; }
        public string Denomination { get; set; }
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
