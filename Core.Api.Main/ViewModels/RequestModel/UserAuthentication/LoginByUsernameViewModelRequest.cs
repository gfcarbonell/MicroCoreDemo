using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.RequestModel.UserAuthentication
{
    public class LoginByUsernameViewModelRequest : LoginViewModelRequest
    {
        public string Username { get; set; }
    }
}
