using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Models;
using MediatR;

namespace Bookshelf.Application.Features.Book.Queries.GetAllBook;

public record GetBookQuery : IRequest<PaginatedList<BookDto>>;

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
        var books = await _bookRepository.GetAsync();

        var data = _mapper.Map<PaginatedList<BookDto>>(books);

        return data;
    }
}
