using Bookshelf.BlazorUI.Contracts;
using Bookshelf.BlazorUI.Services.Base;

namespace Bookshelf.BlazorUI.Services;

public class BookService : BaseHttpService, IBookService
{
    public BookService(IClient client) : base(client)
    {
    }
}
