using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Contract.IServices
{
    public interface IUserService : IService<User>
    {
        Task<User> GetByUsernameAsync(string Username, string Password);
        Task<User> GetByEmailAsync(string Email, string Password);
        Task<User> GetByCellphoneAsync(string Cellphone, string Password);
    }
}
