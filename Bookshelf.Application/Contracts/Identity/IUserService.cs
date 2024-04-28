using Bookshelf.Application.Models.Identity;

namespace Bookshelf.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetUser(string userId);
}