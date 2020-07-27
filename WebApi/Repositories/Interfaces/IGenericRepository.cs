using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repositories.Interfaces
{
    public interface IGenericRepository <T> where  T:BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Insert(T entity);
        Task Update(string id, T entity);
        Task Delete(T entity);
        IQueryable<T> Get();
    }
}
