using AutoMapper;
using Bookshelf.Application.Features.Book.Queries;
using Bookshelf.Domain.Entities;

namespace Bookshelf.Application.MappingProfile
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
        }
    }
}
