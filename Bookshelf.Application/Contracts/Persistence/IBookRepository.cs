﻿using Bookshelf.Application.Models;
using Bookshelf.Domain.Entities;

namespace Bookshelf.Application.Contracts.Persistence;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<bool> IsTitleUnique(string title);
    Task<PaginatedList<Book>> GetBooksAsyncWithPagination(int pageNumber,int pageSize);
    
}
