using ElectronicWallet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectronicWallet.Repositories.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Query { get; }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

        public Task<TEntity> FindFirstAsync();

        public Task<PagedResult<TEntity>> WherePaginatedAsync(Expression<Func<TEntity, bool>> predicate, int page, int size);

        public Task CreateAsync(params TEntity[] entities);

        public Task<List<TEntity>> ReadAsync();

        public Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        public Task<PagedResult<TEntity>> ReadAsync(int? page, int? size);

        public Task UpdateAsync(params TEntity[] entities);

        public Task DeleteAsync(params TEntity[] entities);

        public Task SaveChangesAsync();

        public TEntity UpdateNotNullField(TEntity entity);
        public Task DeleteAllAsync();

    }
}
