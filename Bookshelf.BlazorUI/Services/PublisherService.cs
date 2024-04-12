using Bookshelf.BlazorUI.Contracts;
using Bookshelf.BlazorUI.Services.Base;

namespace Bookshelf.BlazorUI.Services;

public class PublisherService : BaseHttpService, IPublisherService
{
    public PublisherService(IClient client) : base(client)
    {
    }
}
