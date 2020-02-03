using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.Contract.IRepositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T element);
        Task<T> AddAsync(T element);
        bool Delete(int id);
        Task<bool> DeleteAsync(int id);
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        ICollection<T> GetAllPaging(int pageNumber, int pageSize);
        Task<ICollection<T>> GetAllPagingAsync(int pageNumber, int pageSize);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        T Update(int id, T element);
        Task<T> UpdateAsync(int id, T element);
    }
}
