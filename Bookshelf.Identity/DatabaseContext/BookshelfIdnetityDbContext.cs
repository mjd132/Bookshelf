using Bookshelf.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Identity.DatabaseContext;

public class BookshelfIdnetityDbContext : IdentityDbContext<ApplicationUser>
{
	public BookshelfIdnetityDbContext(DbContextOptions<BookshelfIdnetityDbContext> options):base(options)
	{
	
		
	}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(typeof(BookshelfIdnetityDbContext).Assembly);
    }
}
