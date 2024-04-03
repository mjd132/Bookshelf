using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using MediatR;
using System.Linq.Expressions;

namespace Bookshelf.Application.Features.Publisher.Queries.GetPublisherDetails;

public record GetPublisherDetailsQuery(int id) : IRequest<PublisherDetailsDto>;

public class GetPublisherDetailsQueryHandler : IRequestHandler<GetPublisherDetailsQuery, PublisherDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IPublisherRepository _publisherRepository;

    public GetPublisherDetailsQueryHandler(IMapper mapper,IPublisherRepository publisherRepository)
    {
        _mapper = mapper;
        _publisherRepository = publisherRepository;
    }
    public async Task<PublisherDetailsDto> Handle(GetPublisherDetailsQuery request, CancellationToken cancellationToken)
    {
        var publisher =await _publisherRepository.GetByIdAsync(request.id,new List<Expression<Func<Domain.Entities.Publisher, object>>>{p=>p.Books});

        if(publisher == null)
            throw new NotFoundException(nameof(Publisher),request.id);

        var publisherDetails = _mapper.Map<PublisherDetailsDto>(publisher);

        return publisherDetails;
    }
}