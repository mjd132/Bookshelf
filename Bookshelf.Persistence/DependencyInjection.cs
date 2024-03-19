using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Persistence.DatabaseContext;
using Bookshelf.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceSevices(this IServiceCollection services, IConfiguration configuraion)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuraion.GetConnectionString("SqliteDatabase"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();

        return services;
    }
}