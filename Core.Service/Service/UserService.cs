using Core.Domain.Models;
using Core.Repository.Contract.IRepositories.SQLServer.Core;
using Core.Service.Contract.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User Add(User element)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddAsync(User element)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAllPaging(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetAllPagingAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByCellphoneAsync(string Cellphone, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmailAsync(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByUsernameAsync(string Username, string Password)
        {
            throw new NotImplementedException();
        }

        public User Update(int id, User element)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(int id, User element)
        {
            throw new NotImplementedException();
        }
    }
}
