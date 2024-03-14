using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Models;
using Bookshelf.Domain.Entities;
using FluentValidation;
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
    private readonly IValidator<PaginatedList<Domain.Entities.Book>> _paginationValidator;

    public GetBookQueryHandler(IMapper mapper, IBookRepository bookRepository ,IValidator<PaginatedList<Domain.Entities.Book>> paginationValidator)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _paginationValidator = paginationValidator;
    }

    public async Task<PaginatedList<BookDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {

        // get books from repository and validate
        var books = await _bookRepository.GetWithPaginationAync(request.PageNumber, request.PageSize).IsValidPaginationAsync(_paginationValidator, cancellationToken);

        // mapping Book to BookDto
        var booksDto = _mapper.Map<PaginatedList<BookDto>>(books);

        return booksDto;
    }
}
