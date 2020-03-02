using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Main.ViewModels.ResponseModel
{
    public class LoginViewModelResponse
    {
        public JwtTokenViewModelResponse AccessToken { get; set; }
        public ClientViewModelResponse Client { get; set; }
        public EmployeeViewModelResponse Employee { get; set; }
    }
}
