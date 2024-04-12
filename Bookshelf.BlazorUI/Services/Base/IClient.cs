using System.Net.Http;

namespace Bookshelf.BlazorUI.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}


