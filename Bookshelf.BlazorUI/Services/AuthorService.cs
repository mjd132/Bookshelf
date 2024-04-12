using Bookshelf.BlazorUI.Contracts;
using Bookshelf.BlazorUI.Services.Base;

namespace Bookshelf.BlazorUI.Services;

public class AuthorService : BaseHttpService, IAuthorService
{
    public AuthorService(IClient client) : base(client)
    {
    }
}
