using Bookshelf.Application.Contracts.Identity;
using Bookshelf.Application.Models.Identity;
using Bookshelf.Identity.DatabaseContext;
using Bookshelf.Identity.Models;
using Bookshelf.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Serialization;
using System.Text;

namespace Bookshelf.Identity;

public static class IdentityServicesRegistration
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddDbContext<BookshelfIdnetityDbContext> (options =>options.UseSqlite(configuration.GetConnectionString("SqliteDatabase")));

        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookshelfIdnetityDbContext>().AddDefaultTokenProviders();
        services.AddTransient<IAuthService,AuthService>();
        services.AddTransient<IUserService,UserService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters =new TokenValidationParameters
            {
                ValidateIssuerSigningKey=true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime=true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            };
        });

        return services;

    }
}
