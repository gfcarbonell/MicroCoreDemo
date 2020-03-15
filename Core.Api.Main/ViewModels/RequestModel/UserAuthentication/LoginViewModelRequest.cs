using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.RequestModel.UserAuthentication
{
    public abstract class LoginViewModelRequest
    {
        public string Password { get; set; }
        public string Captcha { get; set; }
        public string ReCaptcha { get; set; }
        public bool Remember { get; set; }
    }
}
