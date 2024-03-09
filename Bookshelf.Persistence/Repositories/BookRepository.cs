using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Models;
using Bookshelf.Domain.Entities;
using Bookshelf.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace Bookshelf.Persistence.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<PaginatedList<Book>> GetBooksAsyncWithPagination(int pageNumber, int pageSize)
    {
        return await _context.Books.ToPaginatedListAsync(pageNumber, pageSize);
    }

    public async Task<bool> IsTitleUnique(string title)
    {
        return await _context.Books.AnyAsync(x => x.Title == title);
    }


}
