using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Application.Models;

public class PaginatedList<T>
{
    public int PageNumber { get; private set; }
    public int PageSize { get; private set; }
    public int TotalItems { get; private set; }
    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
    public IReadOnlyList<T> Items { get; set; }

    public PaginatedList(IReadOnlyList<T> items, int count, int pageNumber, int pageSizes)
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSizes;
        TotalItems = count;
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }
}

