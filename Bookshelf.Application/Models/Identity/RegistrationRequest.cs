using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Application.Models.Identity;

public class RegistrationRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}