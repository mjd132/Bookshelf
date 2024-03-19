using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using MediatR;

namespace Bookshelf.Application.Features.Author.Commands;

public record DeleteAuthorCommand(int Id) : IRequest<Unit>;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
{
    private readonly IAuthorRepository _authorRepository;

    public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(request.Id);

        if (author == null)
            throw new NotFoundException(nameof(Author), request.Id);

        await _authorRepository.DeleteAsync(author);

        return Unit.Value;

    }
}