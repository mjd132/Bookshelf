using Bookshelf.Application.Models;
using Bookshelf.Domain.Entities.Common;

namespace Bookshelf.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id, List<System.Linq.Expressions.Expression<Func<T, object>>> includes = null, bool disableTracking = true);
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<PaginatedList<T>> GetWithPaginationAync(int pageNumber, int pageSize);
    Task<ICollection<TEntity>> UpdateRelatedEntityAsync<TEntity>(ICollection<TEntity> originalNavigationProperty=null, ICollection<TEntity> forUpdateNavigationProperty=null) where TEntity : BaseEntity;
    //Task<TEntity> UpdateRelatedEntityAsync<TEntity>(TEntity originalEntity, TEntity forUpdateEntity) where TEntity : BaseEntity;
}
