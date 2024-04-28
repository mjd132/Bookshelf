namespace Bookshelf.Application.Models.Identity;

public class AuthRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
public class User
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}