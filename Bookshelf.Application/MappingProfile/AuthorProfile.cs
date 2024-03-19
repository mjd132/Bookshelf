using AutoMapper;
using Bookshelf.Application.Features.Author.Commands;
using Bookshelf.Application.Features.Author.Queries.GetAllAuthors;
using Bookshelf.Application.Features.Author.Queries.GetAuthorDetail;
using Bookshelf.Domain.Entities;

namespace Bookshelf.Application.MappingProfile;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<AuthorDto, Author>().ReverseMap();
        CreateMap<AuthorDetailDto, Author>().ReverseMap();
        CreateMap<CreateAuthorCommand , Author>();
        CreateMap<UpdateAuthorCommand , Author>();
    }
}