using AutoMapper;
using Bookshelf.Application.Features.Publisher.Queries.GetAllPublishers;
using Bookshelf.Application.Features.Publisher.Queries.GetPublisherDetails;
using Bookshelf.Domain.Entities;

namespace Bookshelf.Application.MappingProfile
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher,PublisherDetailsDto>().ReverseMap();
            CreateMap<Publisher,PublisherDto>().ReverseMap();

        }
    }
}