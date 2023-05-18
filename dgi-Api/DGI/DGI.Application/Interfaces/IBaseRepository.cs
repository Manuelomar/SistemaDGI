using DGI.Domain.Entities;
using System.Linq.Expressions;

namespace DGI.Application.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, IBase
    {
        IQueryable<TEntity> Query();
        Task<TEntity> GetById(string id);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> Delete(string id);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        void RemoveRange(ICollection<TEntity> entities);
    }
}
