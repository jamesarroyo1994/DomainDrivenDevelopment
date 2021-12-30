using Domain.Base;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly List<T> _dbSet;

        public RepositoryBase()
        {
        }

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public Task GetAsync(Expression<Func<T, bool>> expression)
        {
            return null;
        }

        public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return null;
        }

        public Task UpdateAsync(T entity)
        {
            return null;
        }
    }
}
