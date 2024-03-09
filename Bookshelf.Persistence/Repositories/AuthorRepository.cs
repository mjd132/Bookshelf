using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using Bookshelf.Persistence.DatabaseContext;


namespace Bookshelf.Persistence.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext context) : base(context)
    {
    }
}
