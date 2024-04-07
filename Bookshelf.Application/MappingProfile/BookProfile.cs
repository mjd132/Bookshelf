using AutoMapper;
using Bookshelf.Application.Features.Book.Commands;
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
            CreateMap<Book, BookDetailsDto>().ForMember(dest => dest.Publisher, opt => opt.NullSubstitute(null)).ReverseMap();
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();

        }
    }
}
