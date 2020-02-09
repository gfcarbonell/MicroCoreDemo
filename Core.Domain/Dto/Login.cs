using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Dto
{
    public class Login
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }
}
