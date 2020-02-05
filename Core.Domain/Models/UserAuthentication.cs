using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class UserAuthentication
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
