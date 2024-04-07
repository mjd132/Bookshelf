using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using Bookshelf.Domain.Entities;
using Bookshelf.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace Bookshelf.Persistence.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }
    public async Task<bool> IsTitleUnique(string title)
    {
        return await _context.Books.AnyAsync(x => x.Title == title);
    }
    public async Task UpdateBookWithAuthorsAsync(Book bookRequestUpdate)
    {
        var book = await _context.Books.Where(b => b.Id == bookRequestUpdate.Id).Include(b => b.Authors).FirstOrDefaultAsync();

        if (book == null) throw new NotFoundException(nameof(Book), bookRequestUpdate.Id);

        _context.Entry(book).CurrentValues.SetValues(bookRequestUpdate);

        var authors = await _context.Authors.Where(a => bookRequestUpdate.Authors.Select(a => a.Id).ToHashSet().Contains(a.Id) ).ToListAsync();

        book.Authors.Clear();

        foreach (var author in authors)
            book.Authors.Add(author);

        await _context.SaveChangesAsync();
    }
}
