using Core.Domain.Dto;
using Core.Domain.Models.Security;
using Core.Service.Contract.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Service
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public Task<UserAuthentication> LoginByCellphoneAsync(Login login)
        {
            throw new NotImplementedException();
        }

        public Task<UserAuthentication> LoginByEmailAsync(Login login)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAuthentication> LoginByUsernameAsync(Login login)
        {
            return new UserAuthentication()
            {
                User = new User()
                {
                    Id = 1,
                    Username = "gfcarbonell",
                    Password = "gfcarbonell"
                }
            };
        }

        public Task<bool> LogoutAsync(int code)
        {
            throw new NotImplementedException();
        }
    }
}
