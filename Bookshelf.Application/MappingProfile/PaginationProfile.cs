using AutoMapper;
using Bookshelf.Application.Models;

namespace Bookshelf.Application.MappingProfile;

public class PaginationProfile : Profile
{
    public PaginationProfile()
    {
        CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>)); // Generic mapping

        // Specific mapping for PaginatedList<T> where T is a class
        CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>))
            .ForMember("Items", opt => opt.MapFrom("Items"));

    }
}