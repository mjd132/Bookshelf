using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using Bookshelf.Application.Features.Book.Commands;
using Bookshelf.Application.Models;
using MediatR;

namespace Bookshelf.Application.Features.Book.Queries.GetAllBook;

public record GetBookQuery : IRequest<PaginatedList<BookDto>>
{

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

}

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, PaginatedList<BookDto>>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public GetBookQueryHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }
    public async Task<PaginatedList<BookDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {

        //validation
        var validator = new GetBookQueryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Request for Getting Books", validationResult);

        // get books from repository
        var books = await _bookRepository.GetBooksAsyncWithPagination(request.PageNumber, request.PageSize);

        // mapping Book to BookDto
        var booksDto = _mapper.Map<PaginatedList<BookDto>>(books);

        return booksDto;
    }
}
