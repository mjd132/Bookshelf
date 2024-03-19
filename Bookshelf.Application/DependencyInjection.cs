using Bookshelf.Application.Common.Validation;
using Bookshelf.Application.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bookshelf.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IValidator<PaginatedList<Domain.Entities.Book>>), typeof(PaginatedListValidator<Domain.Entities.Book>));
            services.AddScoped(typeof(IValidator<PaginatedList<Domain.Entities.Author>>), typeof(PaginatedListValidator<Domain.Entities.Author>));
            services.AddScoped(typeof(IValidator<PaginatedList<Domain.Entities.Publisher>>), typeof(PaginatedListValidator<Domain.Entities.Publisher>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            return services;
        }
    }
}
