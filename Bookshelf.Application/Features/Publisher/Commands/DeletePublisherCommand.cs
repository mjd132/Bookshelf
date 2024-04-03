using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using MediatR;

namespace Bookshelf.Application.Features.Publisher.Commands;

public record DeletePublisherCommand(int Id) : IRequest<Unit>;

public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand , Unit>
{
    private readonly IPublisherRepository _publisherRepository;

    public DeletePublisherCommandHandler(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<Unit> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
    {
        var publisher = await _publisherRepository.GetByIdAsync(request.Id);

        if (publisher == null) throw new NotFoundException(nameof(publisher),request.Id);

        await _publisherRepository.DeleteAsync(publisher);

        return Unit.Value;
    }
}