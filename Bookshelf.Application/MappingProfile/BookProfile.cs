using AutoMapper;
using Bookshelf.Application.Features.Book.Queries.GetAllBook;
using Bookshelf.Application.Features.Book.Queries.GetBookDetails;
using Bookshelf.Domain.Entities;

namespace Bookshelf.Application.MappingProfile
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<BookDetailsDto, Book>().ReverseMap();

        }
    }
}
