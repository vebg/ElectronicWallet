using AutoMapper;
using AutoMapper.Internal;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Common;
using ElectronicWallet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectronicWallet.Services
{
    public abstract class ManagementServiceBase<T, TEntity> : IManagementServiceBase<T, TEntity> where T : class where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> Repository;
        protected readonly IMapper Mapper;

        public virtual string IdPropertyName => nameof(User.Id);
        public virtual string InactivatePropertyName => nameof(User.IsActive);

        public ManagementServiceBase(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        public virtual async Task<T> CreateAsync(T request)
        {
            if (request == null) return null;

            T result = null;

            try
            {
                var entity = Mapper.Map<TEntity>(request);

                //auditory data
                if (entity is EntityBase _entity)
                {
                    //_entity.CreatedBy = _entity.ModifiedBy = RequestUtils.GetUserEmail();
                    _entity.CreatedAt = _entity.CreatedAt = DateTime.UtcNow;
                    SetAuditoryDataToInternalEntitiesProperties(_entity, true);
                }

                await Repository.CreateAsync(entity);
                await Repository.SaveChangesAsync();

                result = request;
                var id = GetIdValue(entity);
                result.GetType().GetProperty(IdPropertyName).SetValue(result, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating entity. Entity = {name}, Request = {request}, Exception: {ex}", typeof(TEntity).Name, request, ex);
            }

            return result;
        }

        public virtual async Task<PagedResult<T>> GetAllAsync(int page, int size)
        {
            PagedResult<T> result = null;

            try
            {
                var entities = await Repository.ReadAsync(page, size);
                result = Mapper.Map<PagedResult<T>>(entities);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting all entities. Entity = {name}, Page = {page}, Size = {size}, Exception: {ex}", typeof(TEntity).Name, page, size, ex);
            }

            return result;
        }

        public virtual async Task<T> GetAsync(Expression<Func<TEntity, bool>> condition)
        {
            if (condition == null) return null;

            T result = null;

            try
            {
                var entity = await GetEntityByProperty(condition);
                result = Mapper.Map<T>(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting entity by property. Entity = {name}, Condition = {condition}, Exception: {ex}", typeof(TEntity).Name, condition, ex);
            }

            return result;
        }

        public virtual async Task<bool> InactivateAsync(int id)
        {
            if (id == default) return false;

            bool success = false;

            try
            {
                var condition = CreateEntityByPropertyCondition(IdPropertyName, id);
                var entity = await GetEntityByProperty(condition);
                var property = entity.GetType().GetProperty(InactivatePropertyName);
                property.SetValue(entity, false);

                //auditory data
                if (entity is EntityBase _entity)
                {
                    //_entity.ModifiedBy = RequestUtils.GetUserEmail();
                    _entity.UpdatedAt = DateTime.UtcNow;
                    SetAuditoryDataToInternalEntitiesProperties(_entity);
                }

                await Repository.UpdateAsync(entity);
                await Repository.SaveChangesAsync();

                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inactivating entity. Entity = {name}, Id = {id}, Exception: {ex}", typeof(TEntity).Name, id, ex);
            }

            return success;
        }

        public virtual async Task<PagedResult<T>> SearchAsync(Expression<Func<TEntity, bool>> filters, int page, int size)
        {
            if (filters == null) return null;

            PagedResult<T> result = null;

            try
            {
                var entities = await Repository.WherePaginatedAsync(filters, Math.Abs(page), Math.Abs(size));
                result = Mapper.Map<PagedResult<T>>(entities);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching entities. Entity = {name}, Filters = {filters}, Page = {page}, Size = {size}, Exception: {ex}", typeof(TEntity).Name, filters, page, size, ex);
            }

            return result;
        }

        public virtual async Task<bool> UpdateAsync(T request)
        {
            if (request == null) return false;

            bool success = false;

            try
            {
                var id = GetIdValue(request);
                var condition = CreateEntityByPropertyCondition(IdPropertyName, id);
                var entity = await GetEntityByProperty(condition);
                entity = Mapper.Map(request, entity);

                //auditory data
                if (entity is EntityBase _entity)
                {
                    //_entity.ModifiedBy = RequestUtils.GetUserEmail();
                    _entity.UpdatedAt = DateTime.UtcNow;
                    SetAuditoryDataToInternalEntitiesProperties(_entity);
                }

                await Repository.UpdateAsync(entity);
                await Repository.SaveChangesAsync();

                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating entity. Entity = {name}, Request = {request}, Exception: {ex}", typeof(TEntity).Name, request, ex);
            }

            return success;
        }

        public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> condition)
        {
            if (condition == null) return false;

            bool success = true;

            try
            {
                var entity = await GetEntityByProperty(condition);
                await Repository.DeleteAsync(entity);
                await Repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                success = false;
                Console.WriteLine("Error deleting entity. Entity = {name}, Condition = {condition}, Exception: {ex}", typeof(TEntity).Name, condition, ex);
            }

            return success;
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> condition)
        {
            if (condition == null) return false;

            bool exist = false;

            try
            {
                exist = await Repository.ExistsAsync(condition);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking if entity exist. Entity = {name}, Condition = {condition}, Exception: {ex}", typeof(TEntity).Name, condition, ex);
            }

            return exist;
        }

        private async Task<TEntity> GetEntityByProperty(Expression<Func<TEntity, bool>> condition)
        {
            if (condition == null) return null;

            TEntity entity = null;

            try
            {
                entity = await Repository.FindAsync(condition);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting entity by property. Entity = {name}, Condition = {condition}, Exception: {ex}", typeof(TEntity).Name, condition, ex);
            }

            return entity;
        }

        private Expression<Func<TEntity, bool>> CreateEntityByPropertyCondition(string propertyName, object propertyValue)
        {
            var param = Expression.Parameter(typeof(TEntity));
            var condition = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.Equal
                    (
                        Expression.Property(param, propertyName),
                        Expression.Constant(propertyValue, propertyValue.GetType())
                    ),
                param);

            return condition;
        }

        private object GetIdValue(object source) => source.GetType().GetProperty(IdPropertyName).GetValue(source);

        private void SetAuditoryDataToInternalEntitiesProperties(EntityBase entity, bool isCreating = false)
        {
            var entityProperties = entity.GetType().GetProperties().Where(x => x.PropertyType.IsNonStringEnumerable());
            if (entityProperties == null || entityProperties.Count() == 0) return;

            foreach (var entityProperty in entityProperties)
            {
                var entityPropertyValues = entityProperty?.GetValue(entity) as IEnumerable<EntityBase>;
                entityPropertyValues?.ToList().ForEach(x =>
                {
                    if (isCreating)
                    {
                        x.CreatedBy = entity.CreatedBy;
                        x.CreatedAt = entity.CreatedAt;
                    }
                    x.ModifiedBy = entity.ModifiedBy;
                    x.UpdatedAt = entity.UpdatedAt;                   
                    SetAuditoryDataToInternalEntitiesProperties(x, isCreating);
                });
            }
        }
    }
}
