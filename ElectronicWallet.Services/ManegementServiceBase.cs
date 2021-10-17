using AutoMapper;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Repositories.Model;
using ElectronicWallet.Services.Contracts;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectronicWallet.Services
{
    public abstract class ManegementServiceBase<T, TEntity> : IManagementServiceBase<T, TEntity> where T : class where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> Repository;
        protected readonly IMapper Mapper;

        public ManegementServiceBase(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public Task<T> CreateAsync(T request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(Expression<Func<TEntity, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<T>> GetAllAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<TEntity, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InactivateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<T>> SearchAsync(Expression<Func<TEntity, bool>> filters, int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T request)
        {
            throw new NotImplementedException();
        }
    }
}
