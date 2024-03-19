using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using Bookshelf.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Persistence.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {

        return await _context.Authors.Include(p => p.Books).FirstOrDefaultAsync(x => x.Id == id);
    }
}
