using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using MediatR;

namespace Bookshelf.Application.Features.Book.Commands;

public record DeleteBookCommand(int Id) : IRequest<Unit>;


public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{

    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {

        _bookRepository = bookRepository;
    }
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        // rerieve domain entity object
        var book = await _bookRepository.GetByIdAsync(request.Id);

        //verify record exists
        if (book == null)
            throw new NotFoundException(nameof(Book), request.Id);

        //add to database
        await _bookRepository.DeleteAsync(book);
        //return record id
        return Unit.Value;
    }
}