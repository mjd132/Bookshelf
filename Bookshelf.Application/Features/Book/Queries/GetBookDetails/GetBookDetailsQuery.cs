using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using MediatR;

namespace Bookshelf.Application.Features.Book.Queries.GetBookDetails;

public record GetBookDetailsQuery(int Id) : IRequest<BookDetailsDto>;
public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, BookDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public GetBookDetailsQueryHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }
    public async Task<BookDetailsDto> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        if (book == null)
            throw new NotFoundException(nameof(Book), request.Id);

        var data = _mapper.Map<BookDetailsDto>(book);

        return data;
    }
}

