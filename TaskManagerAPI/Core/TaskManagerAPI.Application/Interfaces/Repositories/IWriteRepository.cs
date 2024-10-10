using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.Domain.Entities.Common;

namespace TaskManagerAPI.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        //Create
        Task AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entities);
        void Add(T entity);
        void Add(IEnumerable<T> entities);

        //Update
        Task UpdateAsync(T entity);
        void Update(T entity);

        //Delete
        Task DeleteAsync(T entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        void Delete(Guid id);
        void Delete(Expression<Func<T, bool>> predicate);

        //Extra Functionalities
        Task AddOrUpdateAsync(T entity);
        void AddOrUpdate(T entity);
        IQueryable<T> AsQueryable();

        //Bulks
        Task BulkDeleteById(IEnumerable<Guid> ids);
        Task BulkDelete(Expression<Func<T, bool>> predicate);
        Task BulkDelete(IEnumerable<T> entities);
        Task BulkUpdate(IEnumerable<T> entities);
        Task BulkAdd(IEnumerable<T> entities);
        Task<int> SaveAsync();
    }
}
