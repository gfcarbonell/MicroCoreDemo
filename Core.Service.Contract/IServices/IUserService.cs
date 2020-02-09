using Core.Domain.Models;
using Core.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Contract.IServices
{
    public interface IUserService : IService<User>
    {
        User GetByUsername(string username);
        Task<User> GetByUsernameAsync(string username);
    }
}
