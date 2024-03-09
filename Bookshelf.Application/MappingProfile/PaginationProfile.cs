using AutoMapper;
using Bookshelf.Application.Models;

namespace Bookshelf.Application.MappingProfile;

public class PaginationProfile : Profile
{
    public PaginationProfile()
    {
        //CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>))
        //    .ForMember("Items", opt => opt.MapFrom(src => src.Items.Select(item => item)));


        CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>))
            .ConvertUsing(typeof(PaginatedListConverter<,>));

    }
    
}
public class PaginatedListConverter<TSource, TDest> : ITypeConverter<PaginatedList<TSource>, PaginatedList<TDest>>
{
    public PaginatedList<TDest> Convert(PaginatedList<TSource> source, PaginatedList<TDest> destination, ResolutionContext context)
    {
        var items = context.Mapper.Map<IReadOnlyList<TSource>, IReadOnlyList<TDest>>(source.Items);
        return new PaginatedList<TDest>(items, source.TotalItems, source.PageNumber, source.PageSize);
    }
}