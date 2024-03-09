using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Domain.Entities;
using Bookshelf.Persistence.DatabaseContext;


namespace Bookshelf.Persistence.Repositories;

public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(ApplicationDbContext context) : base(context)
    {
    }
}