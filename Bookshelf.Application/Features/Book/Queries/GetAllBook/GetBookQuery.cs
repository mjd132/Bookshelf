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
    private readonly IValidator<GetBookQuery> _validator;

    public GetBookQueryHandler(IMapper mapper, IBookRepository bookRepository, IValidator<GetBookQuery> validator)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _validator = validator;
    }

    public async Task<PaginatedList<BookDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {

        //validation
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        // get books from repository
        var books = await _bookRepository.GetBooksAsyncWithPagination(request.PageNumber, request.PageSize);



        // mapping Book to BookDto
        var booksDto = _mapper.Map<PaginatedList<BookDto>>(books);

        return booksDto;
    }
}
