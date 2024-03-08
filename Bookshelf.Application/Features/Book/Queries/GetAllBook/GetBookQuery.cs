using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using MediatR;

namespace Bookshelf.Application.Features.Book.Queries.GetAllBook;

public record GetBookQuery : IRequest<List<BookDto>>;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, List<BookDto>>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public GetBookQueryHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }
    public async Task<List<BookDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAsync();

        var data = _mapper.Map<List<BookDto>>(books);

        return data;
    }
}
