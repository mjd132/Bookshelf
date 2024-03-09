using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Persistence.DatabaseContext;
using Bookshelf.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Bookshelf.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection PersistenceSevices(this IServiceCollection services, IConfiguration configuraion)
    {
        services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlite(configuraion.GetConnectionString("SqliteDatabase")); });

        services.AddScoped(typeof(IGenericRepository<>), typeof(IGenericRepository<>));
        services.AddScoped<IBookRepository, IBookRepository>();
        services.AddScoped<IAuthorRepository, IAuthorRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();

        return services;
    }
}