using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Securities
{
    public class Login
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public bool Remember { get; set; }
        public string Password { get; set; }
        public string Captcha { get; set; }
        public string ReCaptcha { get; set; }
    }
}
