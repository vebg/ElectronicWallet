using ElectronicWallet.Database.Entities;
using ElectronicWallet.Database;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Repositories.Extensions;
using ElectronicWallet.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace ElectronicWallet.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ElectronicWalletContext Context;
        public IQueryable<TEntity> Query { get; }

        public RepositoryBase(ElectronicWalletContext context)
        {
            Context = context;
            Query = context.Set<TEntity>();
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.AnyAsync(predicate);
        }

        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.FirstOrDefaultAsync(predicate);
        }

        public virtual Task<TEntity> FindFirstAsync()
        {
            return Query.FirstOrDefaultAsync();
        }

        public virtual Task<PagedResult<TEntity>> WherePaginatedAsync(
            Expression<Func<TEntity, bool>> predicate, int page, int size)
        {
            if (Query is IQueryable<EntityBase>)
                return Query
                    .Where(predicate)
                    .Cast<EntityBase>()
                    .OrderByDescending(x => x.UpdatedAt)
                    .Cast<TEntity>()
                    .AsNoTracking()
                    .ToPagedResultAsync(page, size);

            return Query
                .Where(predicate)
                .AsNoTracking()
                .ToPagedResultAsync(page, size);
        }

        public Task CreateAsync(params TEntity[] entities)
        {
            return Context.AddRangeAsync(entities);
        }

        public virtual Task<List<TEntity>> ReadAsync()
        {
            if (Query is IQueryable<EntityBase>)
                return Query
                    .Cast<EntityBase>()
                    .OrderByDescending(x => x.UpdatedAt)
                    .Cast<TEntity>()
                    .AsNoTracking()
                    .ToListAsync();

            return Query.AsNoTracking().ToListAsync();
        }

        public virtual Task<PagedResult<TEntity>> ReadAsync(int? page, int? size)
        {
            if (Query is IQueryable<EntityBase>)
                return Query
                    .Cast<EntityBase>()
                    .OrderByDescending(x => x.UpdatedAt)
                    .Cast<TEntity>()
                    .AsNoTracking()
                    .ToPagedResultAsync(page, size);

            return Query.AsNoTracking().ToPagedResultAsync(page, size);
        }

        public Task UpdateAsync(params TEntity[] entities)
        {
            Context.UpdateRange(entities);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(params TEntity[] entities)
        {
            Context.RemoveRange(entities);

            return Task.CompletedTask;
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public TEntity UpdateNotNullField(TEntity entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;

            Type type = typeof(TEntity);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(entity, null) == null)
                {
                    try
                    {
                        entry.Property(property.Name).IsModified = false;
                    }
                    catch (Exception)
                    { }
                }
            }
            return entity;
        }

        public Task DeleteAllAsync()
        {
            var entityType = Context.Model.FindEntityType(typeof(TEntity));
            var schema = entityType.GetSchema() ?? "public";
            var tableName = entityType.GetTableName();

            return Context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {schema}.\"{tableName}\"");
        }

        public Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Query.Where(predicate).AsNoTracking().ToListAsync();
        }
    }
}
