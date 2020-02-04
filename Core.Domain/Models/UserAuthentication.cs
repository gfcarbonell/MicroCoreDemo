using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
    public class UserAuthentication
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Password { get; set; }
    }
}
