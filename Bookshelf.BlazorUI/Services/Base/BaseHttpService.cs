﻿using Bookshelf.BlazorUI.Sevices.Base;
using System.Net.Http;

namespace Bookshelf.BlazorUI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;

    public BaseHttpService(IClient client)
    {
        _client = client;
    }
}
