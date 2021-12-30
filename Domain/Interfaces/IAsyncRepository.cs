using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(int id);
        Task GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
    }

}
