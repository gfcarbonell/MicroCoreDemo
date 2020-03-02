using Core.Domain.Models;
using Core.Service.Contract.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Service
{
    public class JwtTokenService : IJwtTokenService
    {
        public JwtToken Add(JwtToken element)
        {
            throw new NotImplementedException();
        }

        public Task<JwtToken> AddAsync(JwtToken element)
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

        public ICollection<JwtToken> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<JwtToken>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<JwtToken> GetAllPaging(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<JwtToken>> GetAllPagingAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public JwtToken GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JwtToken> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public JwtToken Update(int id, JwtToken element)
        {
            throw new NotImplementedException();
        }

        public Task<JwtToken> UpdateAsync(int id, JwtToken element)
        {
            throw new NotImplementedException();
        }
    }
}
