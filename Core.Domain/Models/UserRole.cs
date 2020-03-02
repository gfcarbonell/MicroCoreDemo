using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
