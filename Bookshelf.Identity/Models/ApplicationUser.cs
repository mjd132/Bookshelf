using Microsoft.AspNetCore.Identity;

namespace Bookshelf.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}
