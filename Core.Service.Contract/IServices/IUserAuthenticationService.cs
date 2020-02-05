using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Contract.IServices
{
    public interface IUserAuthenticationService
    {
        Task<UserAuthentication> LoginByUsernameAsync(Login login);
        Task<UserAuthentication> LoginByEmailAsync(Login login);
        Task<UserAuthentication> LoginByCellphoneAsync(Login login);
        Task<bool> LogoutAsync(int code);
    }
}
