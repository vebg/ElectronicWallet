using ElectronicWallet.Common;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectronicWallet.Services.Contracts
{
    public interface IManagementServiceBase<T,TEntity> where T: class where TEntity : class
    {
        public Task<T> CreateAsync(T request);
        public Task<T> GetAsync(Expression<Func<TEntity, bool>> condition);
        public Task<PagedResult<T>> GetAllAsync(int page, int size);
        public Task<bool> UpdateAsync(T request);
        public Task<bool> InactivateAsync(int id);
        public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> condition);
        public Task<PagedResult<T>> SearchAsync(Expression<Func<TEntity, bool>> filters, int page, int size);
        public Task<bool> ExistAsync(Expression<Func<TEntity, bool>> condition);
    }   
    
}
