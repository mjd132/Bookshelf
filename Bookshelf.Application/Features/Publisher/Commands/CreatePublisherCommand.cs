using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Features.Publisher.Queries.GetAllPublishers;
using FluentValidation;
using MediatR;

namespace Bookshelf.Application.Features.Publisher.Commands;

public class CreatePublisherCommand : IRequest<int>
{
    public string Name { get; set; }
    public string? WebsiteUrl { get; set; }
}
public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IPublisherRepository _publisherRepository;
    private readonly IValidator<CreatePublisherCommand> _validator;

    public CreatePublisherCommandHandler(IMapper mapper, IPublisherRepository publisherRepository, IValidator<CreatePublisherCommand> validator)
    {
        _mapper = mapper;
        _publisherRepository = publisherRepository;
        _validator = validator;
    }
    public async Task<int> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
    {
        var publisher = _mapper.Map<Domain.Entities.Publisher>(request);

        await _publisherRepository.CreateAsync(publisher);

        return publisher.Id;
    }
}
