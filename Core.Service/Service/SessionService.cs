using Core.Domain.Models;
using Core.Service.Contract.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Service
{
    public class SessionService : ISessionService
    {
        public Session Add(Session element)
        {
            throw new NotImplementedException();
        }

        public Task<Session> AddAsync(Session element)
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

        public ICollection<Session> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Session>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<Session> GetAllPaging(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Session>> GetAllPagingAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Session GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Session> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Session Update(int id, Session element)
        {
            throw new NotImplementedException();
        }

        public Task<Session> UpdateAsync(int id, Session element)
        {
            throw new NotImplementedException();
        }
    }
}
