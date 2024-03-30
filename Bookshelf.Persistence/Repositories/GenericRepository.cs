using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using Bookshelf.Application.Models;
using Bookshelf.Domain.Entities.Common;
using Bookshelf.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Linq.Expressions;

namespace Bookshelf.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }
    public async Task<T> GetByIdAsync(int id, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();
        if (disableTracking) query = query.AsNoTracking();

        if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<PaginatedList<T>> GetWithPaginationAync(int pageNumber, int pageSize)
    {
        return await _context.Set<T>().ToPaginatedListAsync(pageNumber, pageSize);
    }

    public async Task UpdateAsync(T entity)
    {

        _context.Entry(entity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
    public async Task<ICollection<TEntity>> UpdateRelatedEntity<TEntity>(ICollection<TEntity> originalNavigationProperty, ICollection<TEntity> forUpdateNavigationProperty, string navigationPropertyName = null) where TEntity : BaseEntity
    {

        HashSet<int> toRemoveListId = new();
        HashSet<int> toAddListId = new();

        originalNavigationProperty.XorListsById(forUpdateNavigationProperty, out toRemoveListId, out toAddListId);

        if (toRemoveListId.SetEquals(toAddListId))
            return originalNavigationProperty;
        if (toAddListId.Any())
        {
            var toAddItems = await _context.Set<TEntity>().Where(p => toAddListId.Contains(p.Id)).ToListAsync();
            if (toAddItems != null)
                foreach (var item in toAddItems)
                    originalNavigationProperty.Add(item);
            else
                throw new NotFoundException(typeof(TEntity).Name, toAddItems);
        }
        if (toRemoveListId.Any())
        {
            var toRemoveItems = originalNavigationProperty.Where(p => toRemoveListId.Contains(p.Id)).ToList();
            foreach (var item in toRemoveItems)
                originalNavigationProperty.Remove(item);
        }

        return originalNavigationProperty;
    }

}
public static class RepositoryExtensionMethods
{

    public static void XorListsById<TEntity>(this ICollection<TEntity> list1, ICollection<TEntity> list2, out HashSet<int> resultList1, out HashSet<int> resultList2) where TEntity : BaseEntity
    {
        HashSet<int> listId1 = new HashSet<int>(list1.Select(p => p.Id));
        HashSet<int> listId2 = new HashSet<int>(list2.Select(p => p.Id));

        resultList1 = listId1.Where(entity => !listId2.Contains(entity)).ToHashSet();
        resultList2 = listId2.Where(entity => !listId1.Contains(entity)).ToHashSet();

    }

}