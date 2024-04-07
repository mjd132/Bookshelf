using Bookshelf.Domain.Entities;

namespace Bookshelf.Application.Contracts.Persistence;

public interface IBookRepository : IGenericRepository<Book> 
{
    Task CreateBookWithAuthorsAsync(Book bookRequestCreate);
    Task<bool> IsTitleUnique(string title);
    Task UpdateBookWithAuthorsAsync(Book bookRequestUpdate);
}
