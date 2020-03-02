using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class User
    {
        public User()
        {
            this.UserRoles = new List<UserRole>();
            this.Sessions = new List<Session>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public int StatudId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
