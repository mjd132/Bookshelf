using AutoMapper;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using MediatR;
using System.Linq.Expressions;

namespace Bookshelf.Application.Features.Author.Queries.GetAuthorDetail;

public record GetAuthorDetailQuery(int Id) : IRequest<AuthorDetailDto>;

public class GetAuthorDetailQueryHandler : IRequestHandler<GetAuthorDetailQuery, AuthorDetailDto>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public GetAuthorDetailQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<AuthorDetailDto> Handle(GetAuthorDetailQuery request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(request.Id,new List<Expression<Func<Domain.Entities.Author, object>>>{p=>p.Books });

        if (author == null)
            throw new NotFoundException(nameof(Author), request.Id);

        var authorDto = _mapper.Map<AuthorDetailDto>(author);

        return authorDto;
    }
}
