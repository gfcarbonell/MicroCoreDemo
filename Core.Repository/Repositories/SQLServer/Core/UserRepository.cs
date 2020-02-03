using Core.Repository.Contract.Entities.SQLServer.Core;
using Core.Repository.Contract.IRepositories.SQLServer.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.Repositories.SQLServer.Core
{
    public class UserRepository : IUserRepository
    {
        public UserEntity Add(UserEntity element)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> AddAsync(UserEntity element)
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

        public ICollection<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<UserEntity> GetAllPaging(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserEntity>> GetAllPagingAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public UserEntity Update(int id, UserEntity element)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> UpdateAsync(int id, UserEntity element)
        {
            throw new NotImplementedException();
        }
    }
}
