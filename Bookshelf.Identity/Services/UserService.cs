using Bookshelf.Application.Contracts.Identity;
using Bookshelf.Application.Models.Identity;
using Bookshelf.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Bookshelf.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<User> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return new User
        {
            Email=user.Email,
            Name= user.Name,
            Id= user.Id
        };
    }

    public async Task<List<User>> GetUsers()
    {
        var users= await _userManager.GetUsersInRoleAsync("User");
        return users.Select(u=>new User
        {
            Id = u.Id,
            Name = u.Name,
            Email=u.Email
        }).ToList();

    }
}