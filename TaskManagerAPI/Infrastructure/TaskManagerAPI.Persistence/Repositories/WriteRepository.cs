using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.Application.Interfaces.Repositories;
using TaskManagerAPI.Domain.Entities.Common;
using TaskManagerAPI.Persistence.Context;

namespace TaskManagerAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly TaskManagerDbContext dbContext;

        public WriteRepository(TaskManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected DbSet<T> Table => dbContext.Set<T>();

        public IQueryable<T> AsQueryable() => Table.AsQueryable();

        #region Create
        public virtual async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }
        public virtual void Add(T entity)
        {
            Table.Add(entity);
        }
        public virtual async Task AddAsync(IEnumerable<T> entities)
        {
            if (entities is not null && !entities.Any())
                return;
            await Table.AddRangeAsync(entities);
        }

        public void Add(IEnumerable<T> entities)
        {
            if (entities != null && !entities.Any())
                return;
            Table.AddRange(entities);
        }
        #endregion

        #region Update
        public virtual async Task UpdateAsync(T entity)
        {
            Table.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(T entity)
        {
            Table.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        #endregion

        #region Delete
        public virtual async Task DeleteAsync(T entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
                Table.Attach(entity);
            Table.Remove(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await Table.FindAsync(id);
            await DeleteAsync(entity);
        }
        public virtual async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            dbContext.RemoveRange(Table.Where(predicate));
        }
        public virtual void Delete(T entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
                Table.Attach(entity);
            Table.Remove(entity);
        }
        public virtual void Delete(Guid id)
        {
            var entity = Table.Find(id);
            Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            dbContext.RemoveRange(Table.Where(predicate));
        }
        #endregion

        #region AddOrUpdate
        public virtual Task AddOrUpdateAsync(T entity)
        {
            if (!Table.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
                dbContext.Update(entity);
            return Task.CompletedTask;
        }
        public void AddOrUpdate(T entity)
        {
            if (!Table.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
                dbContext.Update(entity);
        }
        #endregion

        #region Bulk Methods
        public virtual Task BulkDeleteById(IEnumerable<Guid> ids)
        {
            if (ids != null && !ids.Any())
                return Task.CompletedTask;

            dbContext.RemoveRange(Table.Where(i => ids.Contains(i.Id)));
            return Task.CompletedTask;
        }

        public virtual Task BulkDelete(Expression<Func<T, bool>> predicate)
        {
            dbContext.RemoveRange(Table.Where(predicate));
            return Task.CompletedTask;
        }

        public virtual Task BulkDelete(IEnumerable<T> entities)
        {
            if (entities != null && !entities.Any())
                return Task.CompletedTask;

            Table.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task BulkUpdate(IEnumerable<T> entities)
        {
            if (entities != null && !entities.Any())
                return Task.CompletedTask;

            foreach (var entityItem in entities)
            {
                Table.Update(entityItem);
            }
            return Task.CompletedTask;
        }
        public virtual async Task BulkAdd(IEnumerable<T> entities)
        {
            if (entities != null && !entities.Any())
                await Task.CompletedTask;

            await Table.AddRangeAsync(entities);
        }

        public Task<int> SaveAsync()
        {
            return dbContext.SaveChangesAsync();
        }
        #endregion

    }
}
