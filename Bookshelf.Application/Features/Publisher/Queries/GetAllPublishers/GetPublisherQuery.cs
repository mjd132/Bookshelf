using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Models;
using FluentValidation;
using MediatR;

namespace Bookshelf.Application.Features.Publisher.Queries.GetAllPublishers;

public record GetPublisherQuery(int pageNumber,int pageSize) : IRequest<PaginatedList<PublisherDto>>;

public class GetPublisherQueryHandler : IRequestHandler<GetPublisherQuery, PaginatedList<PublisherDto>>
{
    private readonly IMapper _mapper;
    private readonly IPublisherRepository _publisherRepository;
    private readonly IValidator<PaginatedList<Domain.Entities.Publisher>> _validator;

    public GetPublisherQueryHandler(IMapper mapper,IPublisherRepository publisherRepository,IValidator<PaginatedList<Domain.Entities.Publisher>> validator)
    {
        _mapper = mapper;
        _publisherRepository = publisherRepository;
        _validator = validator;
    }
    public async Task<PaginatedList<PublisherDto>> Handle(GetPublisherQuery request, CancellationToken cancellationToken)
    {
        var publishers = await _publisherRepository.GetWithPaginationAync(request.pageNumber,request.pageSize).IsValidPaginationAsync(_validator,cancellationToken);

        var publishersDto = _mapper.Map<PaginatedList<PublisherDto>>(publishers);

        return publishersDto;

    }
}
