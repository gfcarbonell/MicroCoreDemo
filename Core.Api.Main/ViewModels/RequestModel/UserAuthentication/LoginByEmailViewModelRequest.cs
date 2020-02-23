using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.RequestModel.UserAuthentication
{
    public class LoginByEmailViewModelRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
