using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.RequestModel.UserAuthentication
{
    /// <summary>
    /// Login by cellphone
    /// </summary>
    public class LoginByCellphoneViewModelRequest
    {
        public string Cellphone { get; set; }
    }
}
