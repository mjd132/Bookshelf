using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Application.Features.Publisher.Commands;

public class UpdatePublisherCommand: IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? WebsiteUrl { get; set; }

}

public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IPublisherRepository _publisherRepository;
    private readonly IValidator<UpdatePublisherCommand> _validator;

    public UpdatePublisherCommandHandler(IMapper mapper,IPublisherRepository publisherRepository,IValidator<UpdatePublisherCommand> validator)
    {
        _mapper = mapper;
        _publisherRepository = publisherRepository;
        _validator = validator;
    }
    public async Task<Unit> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
    {
        var originalPublisher = await _publisherRepository.GetByIdAsync(request.Id);

        if (originalPublisher == null) throw new NotFoundException(nameof(Publisher),request.Id);

        _mapper.Map(request, originalPublisher);

        await _publisherRepository.UpdateAsync(originalPublisher);

        return Unit.Value;
    }
}
