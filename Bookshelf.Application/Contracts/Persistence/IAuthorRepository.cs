using Bookshelf.Domain.Entities;

namespace Bookshelf.Application.Contracts.Persistence;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<Author> GetAuthorByIdAsync(int id);

}
